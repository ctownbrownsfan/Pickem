using MongoDB.Bson;

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