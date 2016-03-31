using MongoDB.Bson;
using System;

namespace Pickem.Business.Interfaces
{
    public interface ITeam
    {
        ObjectId TeamId { get; }
        string Abbreviation { get; set; }
        string Logo { get; set; }
        string Name { get; set; }
    }
}