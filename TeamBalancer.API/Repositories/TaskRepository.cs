using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamBalancer.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TeamBalancerDbContext dbContext;

        public TaskRepository(TeamBalancerDbContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await dbContext.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem?> UpdateAsync(TaskItem task)
        {
            var existing = await dbContext.Tasks.FindAsync(task.Id);
            if (existing == null) return null;

            dbContext.Entry(existing).CurrentValues.SetValues(task);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await dbContext.Tasks.FindAsync(id);
            if (task == null) return false;

            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}