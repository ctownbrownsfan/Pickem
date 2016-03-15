using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Pickem.Business.Entities;

namespace MongoTests
{
    [TestClass]
    public class MongoTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new MongoClient(new MongoUrl("mongodb://user:=9Spline@ds015289.mlab.com:15289"));
            var db = client.GetDatabase("pickem");
            var collection = db.GetCollection<Team>("Team");
            var result = collection.Find(f => f.Name == "Browns").Count();
            
            Assert.IsTrue(db != null);
            Assert.IsTrue(collection != null);
            Assert.IsTrue(result > 0);

        }
    }
}
