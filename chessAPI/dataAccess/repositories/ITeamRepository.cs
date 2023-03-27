using chessAPI.dataAccess.models;
using chessAPI.models.team;

namespace chessAPI.dataAccess.repositores;

public interface ITeamRepository
{
    Task addTeam(clsNewTeam newTeam);
    Task<clsTeamEntityModel?> getTeam(long id);
}
