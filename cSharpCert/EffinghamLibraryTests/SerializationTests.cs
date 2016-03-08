using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EffinghamLibraryTests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void SerializationTest()
        {
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                
            }
        }
    }
}
