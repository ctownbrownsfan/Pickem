using Core.Common.Contracts;
using System;

namespace Core.Common.Contracts
{
    public interface IPick
    {
        ITeam AwayTeam { get; set; }
        ITeam HomeTeam { get; set; }
        IBoxScore Score { get; set; }
        int WeekPicked { get; set; }
        Guid WinningTeamId { get; }
    }
}