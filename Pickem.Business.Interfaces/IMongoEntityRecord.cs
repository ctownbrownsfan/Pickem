using MongoDB.Bson;

namespace Pickem.Business.Entities
{
    public interface IMongoEntityRecord
    {
        ObjectId Id { get; set; }
    }
}