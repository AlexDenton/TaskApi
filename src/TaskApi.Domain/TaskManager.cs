﻿using System.Collections.Generic;
using TaskApi.Application.Dto;

namespace TaskApi.Domain
{
    using TaskApi.Application;

    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository _TaskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            _TaskRepository = taskRepository;
        }

        private IList<TaskDto> Tasks { get; set; } = new List<TaskDto>
        {
            new TaskDto()
            {
                Name = "task1"
            },
            new TaskDto()
            {
                Name = "task2"
            }
        };

        public IEnumerable<TaskDto> GetTasks()
        {
            return Tasks;
        }

        public void CreateTask(TaskDto taskDto)
        {
            Tasks.Add(taskDto);

            var task = new Task
            {
                Name = taskDto.Name
            };

            _TaskRepository.InsertTask(task);
        }
    }
}