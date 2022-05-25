using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderManager
    {
        public string connectionString = @"Server=localhost;Database=master;Trusted_Connection=True;";
        public List<OrderDTO> OrderAdd()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
               return connection.Query<OrderDTO>
                      (StoredProcedures.OrderUnit_Add, commandType:System.Data.CommandType.StoredProcedure)
                      .ToList();
            }
        }
        public OrderDTO OrderGetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
