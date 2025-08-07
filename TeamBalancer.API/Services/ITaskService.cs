using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Models.DTO;

namespace TeamBalancer.API.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDto>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItemDto> AddAsync(TaskItemDto task);
        Task<TaskItem?> UpdateAsync(TaskItem task);
        Task<bool> DeleteAsync(Guid id);
    }
}