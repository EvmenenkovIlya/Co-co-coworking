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
                    StoredProcedures.AdditionalService_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void  AddAdditionalService(string firstName, string lastName, string phoneNumber, string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingle<AdditionalServiceDTO>(
                    StoredProcedures.AdditionalService_Add,
                    param: new
                    {
                        firstName = firstName,
                        lastName = lastName,
                        phoneNumber = phoneNumber,
                        email = email,
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateAdditionalService(int id, string firstName, string lastName, string phoneNumber, string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AdditionalServiceDTO>(
                StoredProcedures.AdditionalService_Add,
                param: new
                {
                    id = id,
                    firstName = firstName,
                    lastName = lastName,
                    phoneNumber = phoneNumber,
                    email = email,
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
