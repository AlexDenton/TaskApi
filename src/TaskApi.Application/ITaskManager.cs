using System;
using System.Collections.Generic;
using TaskApi.Application.Dto;

namespace TaskApi.Application
{
    public interface ITaskManager
    {
        IEnumerable<TaskDto> GetTasks();

        void CreateTask(TaskDto task);
    }
}