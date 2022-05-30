using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public OrderDTO OrderAdd(int? CustomerId, decimal OrderCost, string OrderStatus, string PaidDate)
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

        public List<OrderDTO> OrderGetByCustomerId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<OrderDTO>(
                    StoredProcedures.Order_GetByCustomerId,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
        public List<OrderDTO> OrderGetAll()
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

        public OrderDTO OrderUpdate(int id, int? CustomerId, decimal OrderCost, int? OrderStatus, int? PaidDate)
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
