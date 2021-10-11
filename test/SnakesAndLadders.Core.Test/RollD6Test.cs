using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Core.Test
{
    [TestClass]
    public class RollD6Test
    {
        [TestMethod]
        public void Roll_OneDice_Result_Between_1_and_6()
        {
            // Arrange
            var roll = new RollD6();
            // Act
            var result = roll.Roll(1);
            // Assert

            Assert.IsTrue(result > 0 && result < 6);

        }
        [TestMethod]
        public void Roll_TwoDice_Result_Between_2_and_12()
        {
            // Arrange
            var roll = new RollD6();
            // Act
            var result = roll.Roll(2);
            // Assert

            Assert.IsTrue(result > 1 && result < 13);

        }
    }
}
