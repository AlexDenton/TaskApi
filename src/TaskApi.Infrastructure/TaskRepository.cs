using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using TaskApi.Application;
using TaskApi.Domain;

namespace TaskApi.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppSettings _AppSettings;

        public TaskRepository(IOptions<AppSettings> appSettings)
        {
            _AppSettings = appSettings.Value;
        }

        public Task InsertTask(Task task)
        {
            using (var connection = new SqlConnection())
            {
                return new Task();
            }
        }
    }
}
