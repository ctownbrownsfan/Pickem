using System.Runtime.Serialization;
using Pickem.Business.Interfaces;

namespace Pickem.Business.Entities
{
    [DataContract]
    public class NFLBoxScore : MongoEntity, IBoxScore
    {

        [DataMember]
        public int HomeTeamScore { get; set; }
        [DataMember]
        public int AwayTeamScore { get; set; }
        [DataMember]
        public int TimeLeft { get; set; }
        [DataMember]
        public bool isFinal
        {
            get
            {
                return TimeLeft == 0;
            }
        }
        
    }
}
