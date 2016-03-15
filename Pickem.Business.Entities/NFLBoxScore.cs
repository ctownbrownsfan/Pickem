using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Business.Entities
{
    [DataContract]
    public class NFLBoxScore : EntityBase, IIdentifiableEntity, IBoxScore
    {
        [DataMember]
        public Guid BoxScoreId { get; set; }

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

        #region IIdentifiableEntity members

        public Guid Id
        {
            get { return BoxScoreId; }
            set { BoxScoreId = value; }
        }
        #endregion
    }
}
