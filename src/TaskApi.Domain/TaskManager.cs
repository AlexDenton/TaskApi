using System.Collections.Generic;
using System.Linq;
using TaskApi.Application.Dto;

namespace TaskApi.Domain
{
    using System.Threading.Tasks;
    using TaskApi.Application;

    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository _TaskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            _TaskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            var tasks = await _TaskRepository.GetTasks();

            return tasks.Select(t => 
                new TaskDto()
                {
                    Id = t.Id,
                    Name = t.Name
                });
        }

        public async System.Threading.Tasks.Task CreateTask(TaskDto taskDto)
        {
            var task = new Task
            {
                Name = taskDto.Name
            };

            await _TaskRepository.InsertTask(task);
        }

        public async Task<TaskDto> UpdateTask(TaskDto taskDto)
        {
            var task = new Task
            {
                Id = taskDto.Id,
                Name = taskDto.Name
            };

            var updatedTask = await _TaskRepository.UpdateTask(task);

            return new TaskDto
            {
                Id = updatedTask.Id,
                Name = updatedTask.Name
            };
        }
    }
}