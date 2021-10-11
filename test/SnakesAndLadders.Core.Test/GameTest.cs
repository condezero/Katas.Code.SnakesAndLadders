using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace SnakesAndLadders.Core.Test
{
    [TestClass]
    public class GameTest
    {

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void InitGame_All_Players_On_Start_Position(int players)
        {
            // Arrange
            var ruleManagerMock = new Mock<IRuleManager>();
            var rollDiceMock = new Mock<IRollDice>();
            var playerStorageMock = new PlayerPositionStorage();
            var auditmock = new Mock<IAuditGame>();
            var options = Options.Create(new GameOptions { DiceNumber = 1 });
            var game = new Game(ruleManagerMock.Object, rollDiceMock.Object, playerStorageMock, auditmock.Object, options);
            // Act

            game.InitGame(players);

            // Assert
            var db = playerStorageMock.GetPrivateField<IDictionary<int, int>>("_playerposition");

            Assert.AreEqual(players, db.Count);
            for (var i = 1; i <= players; i++)
            {
                Assert.AreEqual(1, playerStorageMock.GetPlayerPosition(i));
            }
        }
        [TestMethod]
        public void Roll_Check_Increment_Player()
        {
            // Arrange
            var ruleManagerMock = new Mock<IRuleManager>();

            var rollDiceMock = new Mock<IRollDice>();
            rollDiceMock.Setup(s => s.Roll(It.IsAny<int>())).Returns(3);
            var playerStorageMock = new PlayerPositionStorage();
            var auditmock = new FakeOutputService();
            var options = Options.Create(new GameOptions { DiceNumber = 1 });
            var game = new Game(ruleManagerMock.Object, rollDiceMock.Object, playerStorageMock, auditmock, options);
            game.InitGame(2);

            // Act
            var rollResult = game.Roll();

            // Assert
            Assert.AreEqual(2, rollResult.PlayerId);

            Assert.AreEqual(1, rollResult.PreviousPlayerId);

        }
        [TestMethod]
        public void Roll_Check_Increment_Position_Player()
        {
            // Arrange
            var ruleManagerMock = new Mock<IRuleManager>();
            ruleManagerMock.Setup(s => s.GetRule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new DefaultLimitMoventRule());
            var rollDiceMock = new Mock<IRollDice>();

            rollDiceMock.Setup(s => s.Roll(It.IsAny<int>())).Returns(3);
            var playerStorageMock = new PlayerPositionStorage();
            var auditmock = new FakeOutputService();
            var options = Options.Create(new GameOptions { DiceNumber = 1 });
            var game = new Game(ruleManagerMock.Object, rollDiceMock.Object, playerStorageMock, auditmock, options);
            game.InitGame(2);

            // Act
            var rollResult = game.Roll();

            // Assert
            Assert.AreEqual(2, rollResult.PlayerId);
            Assert.AreEqual(1, rollResult.CurrentPosition);
            Assert.AreEqual(1, rollResult.PreviousPlayerId);
            Assert.AreEqual(4, rollResult.PreviousPlayer_Position);

        }



    }

    [TestClass]
    public class OutputServiceTest
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(6)]
        public void Write_Test(int rollResult)
        {
            // Arrange
            var ruleManagerMock = new Mock<IRuleManager>();
            ruleManagerMock.Setup(s => s.GetRule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new DefaultLimitMoventRule());
            var rollDiceMock = new Mock<IRollDice>();

            rollDiceMock.Setup(s => s.Roll(It.IsAny<int>())).Returns(rollResult);
            var playerStorageMock = new PlayerPositionStorage();
            var auditmock = new FakeOutputService();
            var options = Options.Create(new GameOptions { DiceNumber = 1 });
            var game = new Game(ruleManagerMock.Object, rollDiceMock.Object, playerStorageMock, auditmock, options);
            game.InitGame(2);

            // Act
            var result = game.Roll();

            // Assert

            Assert.AreEqual(rollResult, auditmock.RollResult);
            Assert.IsFalse(string.IsNullOrEmpty(auditmock.Message));

        }
    }
}
