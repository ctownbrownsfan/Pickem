namespace Core.Common.Contracts
{
    public interface ITeam
    {
        int TeamId { get; set; }
        string Abbreviation { get; set; }
        string Logo { get; set; }
        string Name { get; set; }
    }
}