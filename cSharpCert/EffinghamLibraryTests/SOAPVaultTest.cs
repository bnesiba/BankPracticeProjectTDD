using System;
using System.Collections.Generic;
using EffinghamLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class SOAPVaultTest
    {
        private const string testName = "test";
        private const decimal testAmt = 1m;
        [TestMethod]
        public void GetAccountsTest()
        {
            using (IVault v = SOAPVault.Instance)
            {
                var accounts = v.GetAccounts();

                //Assert
                Assert.IsNotNull(accounts);
                Assert.IsTrue(accounts is IEnumerable<BankAccount>);
            }
        }

        [TestMethod]
        public void AddAccountTest()
        {
            //Arrange
            using (IVault v = SOAPVault.Instance)
            {
                BankAccount ba = new TestBankAccount(testAmt, testName);

                //Act
                v.AddAccount(ba);
                BankAccount bb = v.GetAccount(ba.AccountNumber) as BankAccount;

                //Assert
                Assert.AreEqual(ba.AccountNumber, bb.AccountNumber);
                Assert.AreEqual(ba.CustomerName, bb.CustomerName);
                Assert.AreEqual(ba.Balance, bb.Balance);
                Assert.AreEqual(ba.GetType(), bb.GetType());
            }
        }
    }
}
