using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class GetAllCustomerWithActiveSubscriptionManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        //public List<CustomerDTO> GetAllCustomerWithActiveSubscription()
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();


        //    }
        //}
    }
}
