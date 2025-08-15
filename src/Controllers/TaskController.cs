using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        // POST: api/Task
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest("La tarea debe tener un título válido.");
            }

            var newTask = await _taskService.AddAsync(task);
            return Ok(newTask); // Devuelve la tarea creada
        }

        // PUT: api/Task/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var updatedTask = await _taskService.MarkAsCompletedAsync(id);
            if (updatedTask == null)
            {
                return NotFound($"No se encontró la tarea con ID {id}.");
            }

            return Ok(updatedTask); // ✅ Devuelve la tarea actualizada
        }

        // DELETE: api/Task/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _taskService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"No se encontró la tarea con ID {id} para eliminar.");
            }

            return NoContent(); // ✅ 204 OK para eliminación exitosa sin contenido
        }
    }
}