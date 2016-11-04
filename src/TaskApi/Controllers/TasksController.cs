using System.Collections.Generic;
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
        public IEnumerable<TaskDto> Get()
        {
            return _TaskManager.GetTasks();
        }

        [HttpPost]
        public void Post([FromBody]TaskDto task)
        {
            _TaskManager.CreateTask(task);
        }
    }
}