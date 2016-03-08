using System;
using EffinghamLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class BankAccountMultipleCurrencyTest
    {
        private const string testName = "test";
        private const decimal testAmt = 1m;
        private TestBankAccount ba;

        [TestInitialize]
        public void Setup()
        {
            ba = new TestBankAccount(testAmt, testName);
        }
        [TestCleanup]
        public void Cleanup()
        {
            ba = null;
        }

        #region Expected Behavior Tests
        [TestMethod]
        public void DepositPesoTest()
        {
            //arrange
            const decimal amt = 1000m;
            //act
            ba.Deposit(amt, CurrencyType.Peso);
            //assert
            Assert.AreEqual(CurrencyConversion.Convert(amt,CurrencyType.Peso) + testAmt,ba.Balance);
        }

        [TestMethod]
        public void DepositYenTest()
        {
            //arrange
            const decimal amt = 1000m;
            //act
            ba.Deposit(amt, CurrencyType.Yen);
            //assert
            Assert.AreEqual(CurrencyConversion.Convert(amt, CurrencyType.Yen) + testAmt, ba.Balance);

        }

        [TestMethod]
        public void WithdrawPesoTest()
        {
            //arrange
            const decimal amt = 1000m;
            ba.Deposit(amt, CurrencyType.Peso);
            //act
            ba.Withdraw(amt, CurrencyType.Peso);
            //assert
            Assert.AreEqual(ba.Balance, testAmt);
        }

        [TestMethod]
        public void ConstructorWithPesoTest()
        {
            ba = new TestBankAccount(testAmt, testName, CurrencyType.Peso);
            Assert.AreEqual(CurrencyConversion.Convert(testAmt, CurrencyType.Peso), ba.Balance);
        }
        #endregion Expected Behavior Tests

        #region Biz Rule tests

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DepositInvalidCurrencyBizRuleTest()
        {
            ba.Deposit(100m, (CurrencyType)short.MaxValue);
        }
        #endregion Biz Rule Tests
    }
}
