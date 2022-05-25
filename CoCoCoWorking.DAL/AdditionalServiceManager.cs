using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class AdditionalServiceManager
    {
        public string connectionString = @"Server=DESKTOP-U9ABOQU\SQLEXPRESS;Database=CoCoCoworking.DB;Trusted_Connection=True;";
        public List<AdditionalServiceDTO> GetAllAdditionalService()
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

                return connection.QuerySingle<AdditionalServiceDTO>(
                    StoredProcedures.AdditionalService_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void  AddAdditionalService(string name, int? count)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingle<AdditionalServiceDTO>(
                    StoredProcedures.AdditionalService_Add,
                    param: new
                    {
                        name = name,
                        count = count,    
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateAdditionalService(int id, string name, int? count)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AdditionalServiceDTO>(
                StoredProcedures.AdditionalService_Update,
                param: new
                {
                    id = id,
                    name = name,
                    count = count,
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
