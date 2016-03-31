using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Business.Interfaces
{
    public interface IBoxScore
    {
        int HomeTeamScore { get; set; }
        int AwayTeamScore { get; set; }
        int TimeLeft { get; set; }
        bool isFinal { get; }
    }
}
