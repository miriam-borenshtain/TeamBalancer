using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Repositories
{
    public interface ITeamRepository
    {
        Task<Team?> GetTeamByIdAsync(Guid id);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> CreateTeamAsync(Team team);
        Task<Team?> UpdateTeamAsync(Team team);
        Task<bool> DeleteTeamAsync(Guid id);
    }
}
