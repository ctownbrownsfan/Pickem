using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace Pickem.Business.Entities
{
    [DataContract]
    public class Account : MongoEntity
    {
        [DataMember]
        public string LoginEmail { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string ZipCode { get; set; }
        
        
    }
}
