using System;
using System.Threading.Tasks;
using EffinghamLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class BankAccountTests
    {
        private const string testName = "test";
        private const decimal testAmt = 1m;

        private TestBankAccount ba;

        [TestInitialize]
        public void Setup()
        {
            ba = new TestBankAccount(testAmt, testName);
        }

        #region Expected Behavior Tests
        [TestMethod]
        public void ChangeNameTest()
        {
            //arrange
            const string name = "Jeff";

            //act
            ba.CustomerName = name;

            //Assert
            Assert.AreEqual(ba.CustomerName, name);
        }

        [TestMethod]
        public void InstantiateWithNameTest()
        {
            //arrange
            const string name = "Jeff";
            TestBankAccount ba = new TestBankAccount(testAmt, name);

            //Assert
            Assert.AreEqual(ba.CustomerName, name);
        }

        [TestMethod]
        public void InstantiateWithBalanceTest()
        {
            //arrange
            const decimal startingBalance = 10m;
            TestBankAccount ba = new TestBankAccount(startingBalance, testName);

            //Assert
            Assert.AreEqual(ba.Balance, startingBalance);
        }

        [TestMethod]
        public void InstantiateWithBalanceAndName()
        {
            Assert.IsNotNull(ba);
            Assert.IsTrue(ba is BankAccount);
            Assert.AreEqual(testAmt, ba.Balance);
            Assert.AreEqual(testName, ba.CustomerName);
        }

        [TestMethod]
        public void DepositTest()
        {   
            //arrange
            const decimal amt = 100m;
            //act
            ba.Deposit(amt);
            //assert
            Assert.AreEqual(ba.Balance, amt+testAmt);
        }

        [TestMethod]
        public void AccountNumberGenerationTest()
        {
            //Arrange
            TestBankAccount bb = new TestBankAccount(testAmt, testName);

            //Assert
            Assert.AreEqual(ba.AccountNumber + 1, bb.AccountNumber);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            //arrange
            const decimal amt = 100m;
            TestBankAccount ba = new TestBankAccount(amt*2,testName);
            //act
            ba.Withdraw(amt);
            //assert
            Assert.AreEqual(ba.Balance, amt);
        }
        #endregion Expected Behavior Tests

        #region Business Rule Tests
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void NameTooShortBizRuleTest()
        {
            //arrange
            const string name = "1";
            //act
            ba.CustomerName = name;

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NameNullBizRuleTest()
        {
            //arrange
            const string name = null;
            //act
            ba.CustomerName = name;

        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InstantiateAccountWithNegativeBalance()
        {
            //arrange
            const decimal negAmt = -1m;
            TestBankAccount ba = new TestBankAccount(negAmt, testName);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InstantiateAccountWithZeroBalance()
        {
            //arrange
            const decimal zeroAmt = 0m;
            TestBankAccount ba = new TestBankAccount(zeroAmt, testName);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void InstantiateAccountWithOneCharName()
        {
            //arrange
            const string name = "1";
            TestBankAccount ba = new TestBankAccount(testAmt, name);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InstantiateAccountWithNullName()
        {
            //arrange
            const string name = null;
            TestBankAccount ba = new TestBankAccount(testAmt, name);

        }

        #region Deposit Business Rule Tests
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DepositNegativeAmountBizRuleTest()
        {
            //arrange
            const decimal amt = -1m;
            //act
            ba.Deposit(amt);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DepositZeroAmountBizRuleTest()
        {
            //arrange
            const decimal amt = 0m;
            //act
            ba.Deposit(amt);

        }
        #endregion Deposit Business Rule Tests

        #region Withdraw Business Rule Tests
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void WithdrawNegativeAmountBizRuleTest()
        {
            //arrange
            const decimal amt = -1m;
            //act
            ba.Withdraw(amt);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void WithdrawZeroAmountBizRuleTest()
        {
            //arrange
            const decimal amt = 0m;
            //act
            ba.Withdraw(amt);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void WithdrawlMoreThanBalanceBizRuleTest()
        {
            //arrange
            const decimal amt = 200m;
            //act
            ba.Withdraw(amt);
        }
        #endregion Withdraw Business Rule Tests
        #endregion Business Rule Tests

        [TestMethod]
        public void ThreadSafetyTest()
        {
            const decimal smallAmt1 = .33m;
            const decimal smallAmt2 = .9m;
            TestBankAccount ba = new TestBankAccount(100000m, testName);
            Parallel.Invoke(() =>
                            {
                                for (int i = 0; i < 10000; i++)
                                {
                                    ba.Deposit(smallAmt1);
                                }
                            },
                            () => {
                                for (int i = 0; i < 10000; i++)
                                {
                                    ba.Withdraw(smallAmt1);
                                }
                            },
                            () => {
                                for (int i = 0; i < 10000; i++)
                                {
                                    ba.Deposit(smallAmt2);
                                }
                            },
                            () => {
                                for (int i = 0; i < 10000; i++)
                                {
                                    ba.Withdraw(smallAmt2);
                                }
                            }
                            );

            Assert.AreEqual(100000m, ba.Balance);

        }
    }
}
