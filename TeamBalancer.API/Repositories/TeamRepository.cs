using Microsoft.EntityFrameworkCore;
using TeamBalancer.API.Data;
using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamBalancerDbContext dbContext;

        public TeamRepository(TeamBalancerDbContext context)
        {
            dbContext = context;
        }

        public async Task<Team?> GetTeamByIdAsync(Guid id)
        {
            return await dbContext.Teams.FindAsync(id);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await dbContext.Teams.ToListAsync();
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            await dbContext.Teams.AddAsync(team);
            await dbContext.SaveChangesAsync();
            return team;
        }

        public async Task<Team?> UpdateTeamAsync(Team team)
        {
            var existingTeam = await GetTeamByIdAsync(team.Id);
            if (existingTeam == null)
            {
                return null;
            }
            existingTeam.Name = team.Name;
            existingTeam.Description = team.Description;
            existingTeam.ManagerId = team.ManagerId;
            dbContext.Teams.Update(existingTeam);
            await dbContext.SaveChangesAsync();
            return existingTeam;
        }

        public async Task<bool> DeleteTeamAsync(Guid id)
        {
            var team = await GetTeamByIdAsync(id);
            if (team == null)
            {
                return false;
            }
            dbContext.Teams.Remove(team);
            await dbContext.SaveChangesAsync();
            return true;


        }

        public async Task<Employee?> GetTeamManagerAsync(Guid teamId)
        {
            var team = await dbContext.Teams.FindAsync(teamId);
            
            return team.Manager;
        }
    }

}
