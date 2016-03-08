using System;
using EffinghamLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class SavingsAccountTests
    {
        private const string testName = "test";
        private const decimal testAmt = 1m;
        private readonly decimal testAnnualRate = SavingsAccount.InterestRate;
        private readonly decimal testMonthlyRate = SavingsAccount.MonthlyRate;

        [TestMethod]
        public void MonthlyInterestAccumulationTest()
        {
            //arrange
            IInterestBearing sa = new SavingsAccount(testAmt,testName);
            //act
            sa.AddMonthlyInterest();
            //Assert
            Assert.AreEqual(testAmt + (testAmt * testMonthlyRate), ((SavingsAccount)sa).Balance);
        }
    }
}
