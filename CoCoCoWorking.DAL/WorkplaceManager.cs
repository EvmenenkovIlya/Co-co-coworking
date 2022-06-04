using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    internal class WorkplaceManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<WorlplaceDto> GetAllWorkplaces()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<WorlplaceDto>(
                    StoredProcedures.Workplace_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorlplaceDto GetWorkplaceById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorlplaceDto>(
                    StoredProcedures.Workplace_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddWorkplace(WorlplaceDto workplace)
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

        public void UpdateWorkplace(WorlplaceDto workplace)
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
