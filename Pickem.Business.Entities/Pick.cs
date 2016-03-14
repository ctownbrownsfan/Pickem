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
                var teamId = -1;
                if(Score != null && Score.isFinal)
                {
                    if(Score.HomeTeamScore > Score.AwayTeamScore)
                    {
                        teamId = HomeTeamId;
                    }
                    else if(Score.HomeTeamScore > Score.AwayTeamScore)
                    {
                        teamId = AwayTeamId;
                    }
                }
                return teamId;
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
