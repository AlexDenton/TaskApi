namespace TaskApi.Domain
{
    public interface ITaskRepository
    {
        Task InsertTask(Task task);
    }
}