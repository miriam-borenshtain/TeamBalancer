using TeamBalancer.API.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamBalancer.API.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem> AddAsync(TaskItem task);
        Task<TaskItem?> UpdateAsync(TaskItem task);
        Task<bool> DeleteAsync(Guid id);
    }
}