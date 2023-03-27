using chessAPI.models.team;
namespace chessAPI.business.interfaces;

public interface ITeamBusiness
{
    Task<clsTeam?> getTeam(long id);
    Task startTeam(clsNewTeam newTeam);

}