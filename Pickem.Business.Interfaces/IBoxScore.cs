using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IBoxScore
    {
        int HomeTeamScore { get; set; }
        int AwayTeamScore { get; set; }
        int TimeLeft { get; set; }
        bool isFinal { get; }
    }
}
