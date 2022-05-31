using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class CustomerManager
    {
        public string connectionString = ServerOptions.ConnectionOption ;
        public List<CustomersWithActiveSubscriptionDTO> GetAllCustomers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<CustomersWithActiveSubscriptionDTO>(
                    StoredProcedures.Customer_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public CustomersWithActiveSubscriptionDTO GetCustomerByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<CustomersWithActiveSubscriptionDTO>(
                    StoredProcedures.Customer_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void AddCustomer(CustomersWithActiveSubscriptionDTO customer)
        { 
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle(
                    StoredProcedures.Customer_Add,
                    param: new {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void UpdateCustomer(CustomersWithActiveSubscriptionDTO customer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingleOrDefault(
                    StoredProcedures.Customer_Update,
                    param: new
                    {
                        id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}