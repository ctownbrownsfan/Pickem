using Core.Common.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Data
{
    public class MongoDbRepository<T> : IDataRepository<T> where T : class , IIdentifiableEntity, new()
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
            entity.Id = Guid.NewGuid();
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

        public bool Update(T entity)
        {
            if (entity.Id == null)
                return Insert(entity);
            return collection.UpdateOne<T>(f => f.Id == entity.Id, entity.ToBsonDocument()).ModifiedCount > 0;
        }

        public bool Delete(T entity)
        {
            try {
                collection.DeleteOne(f => f.Id == entity.Id);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IList<T>
            SearchFor(Expression<Func<T, bool>> predicate)
        {
            return collection
                .AsQueryable<T>()
                    .Where(predicate.Compile())
                        .ToList();
        }

        public IList<T> GetAll()
        {
            return collection.Find(new BsonDocument()).ToList<T>();
        }

        public T GetById(Guid id)
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

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        T IDataRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
