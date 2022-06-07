using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public int AddOrder(OrderDto order)
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
        public OrderDto GetOrderById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderDto>(
                    StoredProcedures.Order_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<OrderDto> OrderGetByCustomerId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<OrderDto>(
                    StoredProcedures.Order_GetByCustomerId,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
        public List<OrderDto> GetAllOrders()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<OrderDto>
                    (StoredProcedures.Order_GetAll,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }

        public OrderDto UpdateOrder(OrderDto order)
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
        public List<GetAllUnitOrdersFromSpecificOrderDTO> GetAllUnitOrdersFromSpecificOrder(int orderId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return (List<GetAllUnitOrdersFromSpecificOrderDTO>)connection.Query<GetAllUnitOrdersFromSpecificOrderDTO>(
                    StoredProcedures.GetAllUnitOrdersFromSpecificOrder,
                    param: new { OrderId = orderId },
                    commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
