namespace chessAPI.dataAccess.models;

using chessAPI.models.team;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public sealed class clsTeamEntityModel
{
    public clsTeamEntityModel()
    {
    }

    public clsTeamEntityModel(clsNewTeam newTeam, long id)
    {
        this.name = newTeam.name;
        this.createdAt = newTeam.createdAt;
    }

    public ObjectId Id { get; set; }

    [BsonElement("id_team")]
    public long id { get; set; }
    public string name { get; set; }
    public string createdAt { get; set; }


    public static explicit operator clsTeam(clsTeamEntityModel x)
    {
        return new clsTeam()
        {
            id = x.id,
            name = x.name,
            createdAt = x.createdAt
        };
    }
}