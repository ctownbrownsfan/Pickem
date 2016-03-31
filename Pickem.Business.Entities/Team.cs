using System.Runtime.Serialization;
using MongoDB.Bson;
using Pickem.Business.Interfaces;

namespace Pickem.Business.Entities
{
    [DataContract]
    public class Team : MongoEntity, ITeam
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbreviation { get; set; }
        [DataMember]
        public string Logo { get; set; }

        public ObjectId TeamId { get { return Id; } }
    }
}
