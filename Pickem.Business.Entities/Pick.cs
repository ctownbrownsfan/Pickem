using Core.Common.Contracts;
using Core.Common.Core;
using System.Runtime.Serialization;

namespace Pickem.Business.Entities
{
    [DataContract]
    public class Pick : EntityBase, IIdentifiableEntity, IPick
    {
        [DataMember]
        public int PickId { get; set; }
        [DataMember]
        public ITeam HomeTeam { get; set; }
        [DataMember]
        public ITeam AwayTeam { get; set; }
        [DataMember]
        public int WeekPicked { get; set; }
        [DataMember]
        public IBoxScore Score { get; set; }
        [DataMember]
        public int WinningTeamId
        {
            get
            {
                var team = -1;
                if(Score != null && Score.isFinal)
                {
                    if(Score.HomeTeamScore > Score.AwayTeamScore)
                    {
                        team = HomeTeam.TeamId;
                    }
                    else if(Score.HomeTeamScore > Score.AwayTeamScore)
                    {
                        team = AwayTeam.TeamId;
                    }
                }
                return team;
            }
        }

        #region IIdentifiableEntity members

        public int Id
        {
            get { return PickId; }
            set { PickId = value; }
        }

        #endregion
    }
}
