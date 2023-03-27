using chessAPI.dataAccess.models;
using chessAPI.models.team;
using MongoDB.Bson;
using MongoDB.Driver;

namespace chessAPI.dataAccess.repositores;

public sealed class clsTeamRepository : ITeamRepository
{
    private readonly IMongoCollection<clsTeamEntityModel> teamCollection;

    public clsTeamRepository(IMongoCollection<clsTeamEntityModel> teamCollection)
    {
        this.teamCollection = teamCollection;
    }

    private async Task<long> getLastTeam()
    {
        //Empty document tells the driver to count all the documents in the collection
        return await teamCollection.CountDocumentsAsync(new BsonDocument());
    }

    public async Task addTeam(clsNewTeam newTeam)
    {
        var newId = await getLastTeam().ConfigureAwait(false) + 1;
        await teamCollection.InsertOneAsync(new clsTeamEntityModel(newTeam, newId)).ConfigureAwait(false);
    }

    public async Task<clsTeamEntityModel?> getTeam(long id)
    {
        var filter = Builders<clsTeamEntityModel>.Filter.Eq(r => r.id, id);
        return await teamCollection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
    }

}
