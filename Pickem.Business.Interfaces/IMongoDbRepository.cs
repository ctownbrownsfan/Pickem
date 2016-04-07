using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Business.Interfaces
{
    public interface IMongoDbRepository
    {
    }
    public interface IMongoDbRepository<T> : IMongoDbRepository
        where T : class, IMongoEntityRecord, new()
    {
        bool Insert(T entity);

        bool Remove(T entity);

        bool Remove(ObjectId id);

        bool Update(T entity);

        IEnumerable<T> GetAll();
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);

        T GetById(ObjectId id);
    }
}
