using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class AdditionalServiceManager
    {
        public string connectionString = @"Server=.;Database=CoCoCoworking.DB;Trusted_Connection=True;";
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
                    StoredProcedures.Customer_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
