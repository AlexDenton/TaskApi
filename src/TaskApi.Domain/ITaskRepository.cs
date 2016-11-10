using System.Threading.Tasks;

namespace TaskApi.Domain
{
    public interface ITaskRepository
    {
        Task<Domain.Task> InsertTask(Task task);
    }
}