using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using TaskApi.Application;
using TaskApi.Domain;
using System.Threading.Tasks;

namespace TaskApi.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppSettings _AppSettings;

        public TaskRepository(IOptions<AppSettings> appSettings)
        {
            _AppSettings = appSettings.Value;
        }

        public async Task<Domain.Task> InsertTask(Domain.Task task)
        {
            using (var connection = new SqlConnection(_AppSettings.ConnectionStrings.DefaultConnection))
            {
                var parameters = new DynamicParameters(
                    new
                    {
                        Name = task.Name
                    });

                parameters.Add("ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync(
                    "Insert_Task",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                task.Id = parameters.Get<int>("ID").ToString();

                return task;
            }
        }
    }
}
