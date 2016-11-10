using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApi.Application.Dto;

namespace TaskApi.Application
{
    public interface ITaskManager
    {
        Task<IEnumerable<TaskDto>> GetTasks();

        Task CreateTask(TaskDto taskDto);
    }
}