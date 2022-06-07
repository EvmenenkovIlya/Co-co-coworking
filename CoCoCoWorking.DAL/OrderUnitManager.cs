using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderUnitManager
    {
        public string connectionString = ServerOptions.ConnectionOption;
        public List<OrderUnitDto> GetAllOrderUnits()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<OrderUnitDto>(
                    StoredProcedures.OrderUnit_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public OrderUnitDto GetOrderUnitByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderUnitDto>(
                    StoredProcedures.OrderUnit_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddOrderUnit(OrderUnitDto orderUnit)
        {
           
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingle(
                    StoredProcedures.OrderUnit_Add,
                     param: new
                     { 
                         startDate = orderUnit.StartDate,
                         endDate = orderUnit.EndDate,
                         roomId = orderUnit.RoomId,
                         workPlaceId = orderUnit.WorkPlaceId,
                         workPlaceInRoomId= orderUnit.WorkPlaceInRoomId,
                         AdditionalServiceId = orderUnit.AdditionalServiceId,
                         orderId = orderUnit.OrderId,
                         orderUnitCost = orderUnit.OrderUnitCost

                     },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateOrderUnit(OrderUnitDto orderUnit)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault(
                StoredProcedures.OrderUnit_Update,
                 param: new
                 {
                     id = orderUnit.Id,
                     startDate = orderUnit.StartDate,
                     endDate = orderUnit.EndDate,
                     roomId = orderUnit.RoomId,
                     workPlaceId = orderUnit.WorkPlaceId,
                     workPlaceInRoomId= orderUnit.WorkPlaceInRoomId,
                     additionalServiceId = orderUnit.AdditionalServiceId,
                     orderId = orderUnit.OrderId,
                     orderUnitCost = orderUnit.OrderUnitCost

                 },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
