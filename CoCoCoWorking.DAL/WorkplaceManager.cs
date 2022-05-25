using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    internal class WorkplaceManager
    {
        public string connectionString = @"Server=.;Database=CoCoCoworking.DB;Trusted_Connection=True;";

        public List<WorkplaceDTO> GetAllWorkplaces()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<WorkplaceDTO>(
                    StoredProcedures.Workplace_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkplaceDTO GetWorkplaceById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkplaceDTO>(
                    StoredProcedures.Workplace_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddWorkplace(int roomId, int number)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle<WorkplaceDTO>(
                    StoredProcedures.Workplace_Add,
                    param: new {
                        RoomId = roomId,
                        Number = number
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateWorkplace(int id, int roomId, int number)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle<WorkplaceDTO>(
                    StoredProcedures.Workplace_Update,
                    param: new
                    {
                        Id = id,
                        RoomId = roomId,
                        Number = number
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
