using MongoDB.Bson;

namespace Pickem.Business.Interfaces
{
    public interface IMongoEntityRecord
    {
        ObjectId Id { get; set; }
    }
}