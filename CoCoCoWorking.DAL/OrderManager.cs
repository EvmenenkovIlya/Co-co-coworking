using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public OrderDTO AddOrder(int? CustomerId, decimal OrderCost, string OrderStatus, string PaidDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle
                       (StoredProcedures.Order_Add,
                       param: new
                       {
                           CustomerId = CustomerId,
                           OrderCost = OrderCost,
                           OrderStatus = OrderStatus,
                           PaidDate = PaidDate
                       },
                       commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public OrderDTO GetOrderById(int id)
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
        public List<OrderDTO> GetAllOrder()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<OrderDTO>
                    (StoredProcedures.Order_GetAll,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }

        public OrderDTO UpdateOrder(int id, int? CustomerId, decimal OrderCost, int? OrderStatus, int? PaidDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingleOrDefault(
                    StoredProcedures.Order_GetById,
                    param: new { 
                        id = id,
                        CustomerId= CustomerId,
                        OrderCost= OrderCost,
                        OrderStatus= OrderStatus,
                        PaidDate= PaidDate
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
