using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Core;
using System.Collections.Generic;

namespace SnakesAndLadders.Core.Test
{
    [TestClass]
    public class RuleManagerTest
    {
        [TestMethod]
        public void GetRule_Not_Error()
        {
            // Arrange
            var ruleList = new List<IRule>();
            ruleList.Add(new FakeRule());

            var manager = new RuleManager(ruleList);
           
            // Act

            var rule = manager.GetRule(1, 1, 1);

            // Assert

            Assert.IsNotNull(rule);
            Assert.IsTrue(rule is FakeRule);

        }
        [TestMethod]
        [ExpectedException(typeof(GameException))]
        public void GetRule_throws_GameException()
        {
            // Arrange
            var ruleList = new List<IRule>();
            

            var manager = new RuleManager(ruleList);

            // Act

            var rule = manager.GetRule(1, 1, 1);

            // Assert

            
        }

        private class FakeRule : IRule
        {
            public RuleResult ApplyRule(int player, int currentPosition, int rollResult)
            {
                throw new System.NotImplementedException();
            }

            public bool CanApply(int player, int currentPosition, int rollResult) => true;
           
        }
    }
}
