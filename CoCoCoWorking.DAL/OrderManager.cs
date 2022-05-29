using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public OrderDTO AddOrder(OrderDTO order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle
                       (StoredProcedures.Order_Add,
                       param: new
                       {
                           CustomerId = order.CustomerId,
                           OrderCost = order.OrderCost,
                           OrderStatus = order.OrderStatus,
                           PaidDate = order.PaidDate
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
        public List<OrderDTO> GetAllOrders()
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

        public OrderDTO UpdateOrder(OrderDTO order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingleOrDefault(
                    StoredProcedures.Order_GetById,
                    param: new { 
                        id = order.Id,
                        CustomerId = order.CustomerId,
                        OrderCost = order.OrderCost,
                        OrderStatus = order.OrderStatus,
                        PaidDate = order.PaidDate
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
