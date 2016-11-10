using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Application;
using TaskApi.Application.Dto;

namespace TaskApi.Controllers
{
    [Route("tasks")]
    public class TasksController : Controller
    {
        private readonly ITaskManager _TaskManager;

        public TasksController(ITaskManager taskManager)
        {
            _TaskManager = taskManager;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskDto>> Get()
        {
            return await _TaskManager.GetTasks();
        }

        [HttpPut("{id}")]
        public async Task<TaskDto> PutTask(string id, [FromBody]TaskDto taskDto)
        {
            taskDto.Id = id;
            return await _TaskManager.UpdateTask(taskDto);
        }


        [HttpPost]
        public void Post([FromBody]TaskDto task)
        {
            _TaskManager.CreateTask(task);
        }
    }
}