using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using TaskApi.Application;
using TaskApi.Domain;
using System.Threading.Tasks;
using Task = TaskApi.Domain.Task;

namespace TaskApi.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppSettings _AppSettings;

        public TaskRepository(IOptions<AppSettings> appSettings)
        {
            _AppSettings = appSettings.Value;
        }

        public async Task<IEnumerable<Domain.Task>> GetTasks()
        {
            using (var connection = new SqlConnection(_AppSettings.ConnectionStrings.DefaultConnection))
            {
                return await connection.QueryAsync<Domain.Task>("Get_Tasks");
            }
        }

        public async Task<Task> UpdateTask(Task task)
        {
            using (var conneciton = new SqlConnection(_AppSettings.ConnectionStrings.DefaultConnection))
            {
                await conneciton.ExecuteAsync(
                    "Update_Task",
                    new
                    {
                        ID = task.Id,
                        Name = task.Name
                    },
                    commandType: CommandType.StoredProcedure);

                return task;
            }
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
