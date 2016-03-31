using Core.Common.Contracts;
using MongoDB.Bson;
using System;

namespace Pickem.Business.Interfaces
{
    public interface IPick
    {
        ITeam AwayTeam { get; set; }
        ITeam HomeTeam { get; set; }
        IBoxScore Score { get; set; }
        int WeekPicked { get; set; }
        ObjectId WinningTeamId { get; }
    }
}