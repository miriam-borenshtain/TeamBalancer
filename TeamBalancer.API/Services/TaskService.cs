using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Models.DTO;
using TeamBalancer.API.Repositories;

namespace TeamBalancer.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
        {
            var tasks =  await taskRepository.GetAllAsync();
            return mapper.Map<IEnumerable<TaskItemDto>>(tasks);

        }

        public Task<TaskItem?> GetByIdAsync(Guid id) => taskRepository.GetByIdAsync(id);

        public async Task<TaskItemDto> AddAsync(TaskItemDto task) {
            var taskItem = mapper.Map<TaskItem>(task);
            taskItem = await taskRepository.AddAsync(taskItem);
            return mapper.Map<TaskItemDto>(taskItem);
        }

        public Task<TaskItem?> UpdateAsync(TaskItem task) => taskRepository.UpdateAsync(task);

        public Task<bool> DeleteAsync(Guid id) => taskRepository.DeleteAsync(id);
    }
}