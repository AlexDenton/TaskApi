using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskApi.Domain
{
    public interface ITaskRepository
    {
        Task<Domain.Task> InsertTask(Task task);

        Task<IEnumerable<Domain.Task>> GetTasks();

        Task<Domain.Task> UpdateTask(Domain.Task task);
    }
}