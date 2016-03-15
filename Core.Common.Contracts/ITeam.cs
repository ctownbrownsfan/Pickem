using System;

namespace Core.Common.Contracts
{
    public interface ITeam
    {
        Guid TeamId { get; set; }
        string Abbreviation { get; set; }
        string Logo { get; set; }
        string Name { get; set; }
    }
}