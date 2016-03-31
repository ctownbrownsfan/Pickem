using System;

namespace Core.Common.Contracts
{
    public interface ITeam
    {
        string Abbreviation { get; set; }
        string Logo { get; set; }
        string Name { get; set; }
    }
}