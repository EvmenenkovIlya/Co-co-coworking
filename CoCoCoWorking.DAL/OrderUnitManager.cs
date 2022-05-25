using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderUnitManager
    {
        public string connectionString = @"Server=DESKTOP-U9ABOQU\SQLEXPRESS;Database=CoCoCoworking.DB;Trusted_Connection=True;";
        public List<OrderUnitDTO> GetAllOrderUnit()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<OrderUnitDTO>(
                    StoredProcedures.OrderUnit_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public OrderUnitDTO GetOrderUnitByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderUnitDTO>(
                    StoredProcedures.OrderUnit_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddOrderUnit(string startDate, string endDate, int roomId, int workPlaceId,
                                             int workPlaceInRoomId, int AdditionalServiceId, int orderId, decimal orderUnitCost)
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingle<OrderUnitDTO>(
                    StoredProcedures.OrderUnit_Add,
                     param: new
                     { 
                         startDate = startDate,
                         endDate = endDate,
                         roomId = roomId,
                         workPlaceId = workPlaceId,
                         workPlaceInRoomId= workPlaceInRoomId,
                         AdditionalServiceId = AdditionalServiceId,
                         orderId = orderId,
                         orderUnitCost = orderUnitCost

                     },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateOrderUnit(int id, string startDate, string endDate, int roomId, int workPlaceId, int workPlaceInRoomId, 
                                                                     int additionalServiceId, int orderId, decimal orderUnitCost)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderUnitDTO>(
                StoredProcedures.OrderUnit_Update,
                 param: new
                 {
                     id = id,
                     startDate = startDate,
                     endDate = endDate,
                     roomId = roomId,
                     workPlaceId = workPlaceId,
                     workPlaceInRoomId= workPlaceInRoomId,
                     additionalServiceId = additionalServiceId,
                     orderId = orderId,
                     orderUnitCost = orderUnitCost

                 },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
