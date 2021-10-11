using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Core;

namespace SnakesAndLadders.Core.Test
{
    [TestClass]
    public class DefaultLimitMovementRuleTest
    {
        [TestMethod]
        public void CanApply_Valid_Movement_Return_True()
        {
            // Arrange
            var rule = new DefaultLimitMoventRule();
            // Act
            var result = rule.CanApply(1, 90, 6);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanApply_InValid_Movement_Return_False()
        {
            // Arrange
            var rule = new DefaultLimitMoventRule();
            // Act
            var result = rule.CanApply(1, 96, 6);
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ApplyRule_Test()
        {
            // Arrange
            var rule = new DefaultLimitMoventRule();
            // Act
            var result = rule.ApplyRule(1, 80, 4);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(84, result.NextPosition);
            Assert.IsTrue(result.CanApplyMoreRules);

        }
    }

}
