﻿using Core.Common.Contracts;
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
    public class Team : EntityBase, IIdentifiableEntity, ITeam
    {
        [DataMember]
        public Guid TeamId {get;set;}
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Abbreviation { get; set; }
        [DataMember]
        public string Logo { get; set; }

        #region IIdentifiableEntity members

        public Guid Id
        {
            get { return TeamId; }
            set { TeamId = value; }
        }

        #endregion
    }
}
