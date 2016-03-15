using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Runtime.Serialization;

namespace Pickem.Business.Entities
{
    [DataContract]
    public class Pick : EntityBase, IIdentifiableEntity, IPick
    {
        [DataMember]
        public Guid PickId { get; set; }
        [DataMember]
        public ITeam HomeTeam { get; set; }
        [DataMember]
        public ITeam AwayTeam { get; set; }
        [DataMember]
        public int WeekPicked { get; set; }
        [DataMember]
        public IBoxScore Score { get; set; }
        [DataMember]
        public Guid WinningTeamId
        {
            get
            {
                Guid team = Guid.Empty;
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

        public Guid Id
        {
            get { return PickId; }
            set { PickId = value; }
        }

        #endregion
    }
}
