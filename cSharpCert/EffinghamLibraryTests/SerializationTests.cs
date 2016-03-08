using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using EffinghamLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class SerializationTests
    {
        private const string testName = "test";
        private const decimal testAmt = 1m;

        private IBankAccount ba;

        [TestInitialize]
        public void Setup()
        {
            ba = new BankAccount(testAmt, testName);
        }

        [TestMethod]
        public void SerializationTest()
        {
            //arrange/act
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, ba);
                ms.Position = 0;
                BankAccount bb = formatter.Deserialize(ms) as BankAccount;

                //Assert
                Assert.IsNotNull(bb);
                Assert.IsTrue(bb.CustomerName == testName);
                Assert.IsTrue(bb.Balance == testAmt);
                Assert.IsTrue(bb.AccountNumber == ba.AccountNumber);

            }
            

        }
    }
}
