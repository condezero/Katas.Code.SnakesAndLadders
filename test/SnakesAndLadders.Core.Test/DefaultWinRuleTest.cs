using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Core;

namespace SnakesAndLadders.Core.Test
{
    [TestClass]
    public class DefaultWinRuleTest
    {
        [TestMethod]
        public void CanApply_Is_True_When_Movement_Ends()
        {
            // Arrange
            var rule = new DefaultWinRule();

            // Act

            var result = rule.CanApply(1, 96, 4);

            // Assert

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanApply_Is_False_When_Movement_Ends()
        {
            // Arrange
            var rule = new DefaultWinRule();

            // Act

            var result = rule.CanApply(1, 95, 4);

            // Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ApplyRule_Win_Game()
        {
            // Arrange
            var rule = new DefaultWinRule();
            var expectedMessage = "Player_1 wins!!!";
            // Act
            var result = rule.ApplyRule(1, 96, 4);
            // Assert

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsWinMovement);
            Assert.AreEqual(expectedMessage, result.Reason);
            Assert.AreEqual(100, result.NextPosition);


        }
    }
}
