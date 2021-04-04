using MongoDB.Driver;
using NUnit.Framework;
using Resume.Mongo.Data.Services;
using System.Collections.Generic;

namespace MongoTest
{
    public class Tests
    {
        string conString = "mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb";
        MongoServices service = null;
        [SetUp]
        public void Setup()
        {
            this.service = new MongoServices(this.conString);
        }

        [Test]
        public void TestConnection()
        {
            bool passed = false;

            passed = this.service.TestConnection().Result;

            Assert.IsTrue(passed);
        }

        [Test]
        public void ContainsDbNames()
        {
            List<string> list = this.service.GetDatabaseNames().Result;

            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void ContainsLocalDB()
        {
            string name = "local";

            List<string> list = this.service.GetDatabaseNames().Result;

            Assert.IsTrue(list.Contains(name));
        }
    }
}