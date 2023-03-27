using chessAPI.dataAccess.repositores;
using chessAPI.models.team;
using chessAPI.business.interfaces;

namespace chessAPI.business.impl;

public sealed class clsTeamBusiness : ITeamBusiness
{
    internal readonly ITeamRepository teamRepository;

    public clsTeamBusiness(ITeamRepository teamRepository) => this.teamRepository = teamRepository;

    public async Task startTeam(clsNewTeam newTeam) => await teamRepository.addTeam(newTeam).ConfigureAwait(false);

    public async Task<clsTeam?> getTeam(long id)
    {
        var x = await teamRepository.getTeam(id).ConfigureAwait(false);
        return x != null ? (clsTeam)x : null;
    }

}
