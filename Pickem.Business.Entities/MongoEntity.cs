using MongoDB.Bson;
using Core.Common.Core;
using Pickem.Business.Interfaces;

namespace Pickem.Business.Entities
{
    public class MongoEntity : EntityBase, IMongoEntityRecord
    {
        public ObjectId Id
        {
            get; set;
        }
    }
}
