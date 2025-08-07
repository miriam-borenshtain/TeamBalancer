using Microsoft.AspNetCore.Mvc;
using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Models.DTO;
using TeamBalancer.API.Services;

namespace TeamBalancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAll()
        {
            var tasks = await taskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetById(Guid id)
        {
            var task = await taskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> Add(TaskItemDto task)
        {
            var created = await taskService.AddAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskItem task)
        {
            if (id != task.Id) return BadRequest();
            var updated = await taskService.UpdateAsync(task);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await taskService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}