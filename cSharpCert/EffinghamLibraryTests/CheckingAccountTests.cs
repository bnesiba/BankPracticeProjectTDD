using System;
using EffinghamLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class CheckingAccountTests
    {
        private const string testName = "test";
        private const decimal testAmt = 1m;
        [TestMethod]
        public void OverdraftOKTest()
        {
            //
            const decimal amt = 40m;
            CheckingAccount ca = new CheckingAccount(testAmt, testName);
            //act
            ca.Withdraw(amt);
            //assert
            Assert.AreEqual(testAmt - amt, ca.Balance);
            Assert.IsTrue(ca.Balance < 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void OverdraftBizRuleTestTest()
        {
            //
            const decimal amt = 60m;
            CheckingAccount ca = new CheckingAccount(testAmt, testName);
            //act
            ca.Withdraw(amt);

        }

        [TestMethod]
        public void ZeroBalancetest()
        {
            CheckingAccount ca = new CheckingAccount(testAmt, testName);
            ca.Withdraw(testAmt);
            Assert.AreEqual(0, ca.Balance);
        }
    }
}
