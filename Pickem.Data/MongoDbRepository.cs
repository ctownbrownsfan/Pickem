using Core.Common.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using Pickem.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Data
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : class , IMongoEntityRecord, new()
    {
        private IMongoDatabase database;
        private IMongoCollection<T> collection;

        public MongoDbRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public bool Insert(T entity)
        {
            entity.Id = ObjectId.Empty;
            try
            {
                collection.InsertOne(entity);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Remove(T entity)
        {
            if (entity != null)
            {
                return Remove(entity.Id);
            }
            return false;
        }
        public bool Remove(ObjectId id)
        {
            try
            {
                collection.DeleteOne(f => f.Id == id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(T entity)
        {
            if (entity.Id == null)
                return Insert(entity);
            return collection.UpdateOne<T>(f => f.Id == entity.Id, entity.ToBsonDocument()).ModifiedCount > 0;
        }

        public IEnumerable<T>
            SearchFor(Expression<Func<T, bool>> predicate)
        {
            return collection
                .AsQueryable<T>()
                    .Where(predicate.Compile())
                        .ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList<T>();
        }

        public T GetById(ObjectId id)
        {
            return (T)collection.Find(f=>f.Id == id);
        }
        
    
        #region Private Helper Methods
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());

            database = client.GetDatabase(GetDatabaseName());
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbConnectionString")
                        .Replace("{DB_NAME}", GetDatabaseName());
        }

        private string GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbDatabaseName");
        }

        private void GetCollection()
        {
            collection = database
                .GetCollection<T>(typeof(T).Name);
        }

        #endregion
    }
}
