using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class AdditionalServiceManager
    {
        public string connectionString = ServerOptions.ConnectionOption;
        public List<AdditionalServiceDTO> GetAllAdditionalServices()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<AdditionalServiceDTO>(
                    StoredProcedures.AdditionalService_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public AdditionalServiceDTO GetAdditionalServiceByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle(
                    StoredProcedures.AdditionalService_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void  AddAdditionalService(AdditionalServiceDTO additionalService)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingleOrDefault(
                    StoredProcedures.AdditionalService_Add,
                    param: new
                    {
                        name = additionalService.Name,
                        count = additionalService.Count,    
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateAdditionalService(AdditionalServiceDTO additionalService)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AdditionalServiceDTO>(
                StoredProcedures.AdditionalService_Update,
                param: new
                {
                    id = additionalService.Id,
                    name = additionalService.Name,
                    count = additionalService.Count,
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteAdditionalService(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AdditionalServiceDTO>(
                StoredProcedures.AdditionalService_SoftDelete,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
