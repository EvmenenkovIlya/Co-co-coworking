using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class WorkplaceManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<WorkPlaceDto> GetAllWorkplaces()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<WorkPlaceDto>(
                    StoredProcedures.Workplace_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkPlaceDto GetWorkplaceById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkPlaceDto>(
                    StoredProcedures.Workplace_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddWorkplace(WorkPlaceDto workplace)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle(
                    StoredProcedures.Workplace_Add,
                    param: new {
                        RoomId = workplace.RoomId,
                        Number = workplace.Number
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateWorkplace(WorkPlaceDto workplace)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingleOrDefault(
                    StoredProcedures.Workplace_Update,
                    param: new
                    {
                        Id = workplace.Id,
                        RoomId = workplace.RoomId,
                        Number = workplace.Number
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
