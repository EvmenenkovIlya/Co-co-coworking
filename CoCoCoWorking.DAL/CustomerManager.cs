using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class CustomerManager
    {
        public string connectionString = @"Server=.\MSSQLSERVER;Database=CoCoCoworking.DB;Trusted_Connection=True;";//тут ошибка где-то
        public List<CustomerDTO> GetAllCustomers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<CustomerDTO>(
                    StoredProcedures.Customer_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public CustomerDTO GetCustomerByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<CustomerDTO>(
                    StoredProcedures.Customer_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
