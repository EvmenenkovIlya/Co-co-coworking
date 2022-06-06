using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class RoomManager
    {
        public string connectionString = ServerOptions.ConnectionOption;
        public List<RoomDto> GetAllRooms()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<RoomDto>(
                    StoredProcedures.Room_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public RoomDto GetRoomByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<RoomDto>(
                    StoredProcedures.Room_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void AddRoom(RoomDto room)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle(
                    StoredProcedures.Room_Add,
                    param: new
                    {
                        Name = room.Name,
                        WorkPlaceNumber = room.WorkPlaceNumber
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void UpdateRoom(RoomDto room)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingleOrDefault(
                    StoredProcedures.Room_Update,
                    param: new
                    {
                        id = room.Id,
                        Name = room.Name,
                        WorkPlaceNumber = room.WorkPlaceNumber
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public List<AllRoomsWithPriceWithPeriodRentaHDto> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentaHDto> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentaHDto>();

                connection.Query<AllRoomsWithPriceWithPeriodRentaHDto, RoomDto, RentPriceDto, AllRoomsWithPriceWithPeriodRentaHDto>
                (StoredProcedures.GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour,
                (allroom, room, rentprice) =>
                {

                    if (!result.ContainsKey(allroom.StartDate))
                    {
                        result.Add(allroom.StartDate, allroom);
                    }
                    AllRoomsWithPriceWithPeriodRentaHDto crnt = result[allroom.StartDate];

                    crnt.Rooms.Add(room);
                    crnt.Rentprices.Add(rentprice);


                    return crnt;
                },

                commandType: System.Data.CommandType.StoredProcedure,
                splitOn: "StartDate, Name, RegularPrice "
                );
                return result.Values.ToList();
            }
        }

        public List<AllRoomAndWorkPlaceBusyOrFreeDto> GetAllRoomAndWorkPlaceBusyOrFree()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, AllRoomAndWorkPlaceBusyOrFreeDto> result = new Dictionary<int, AllRoomAndWorkPlaceBusyOrFreeDto>();

                connection.Query<AllRoomAndWorkPlaceBusyOrFreeDto, WorkPlaceDto, RentPriceDto, OrderUnitDto, AllRoomAndWorkPlaceBusyOrFreeDto>
                (StoredProcedures.GetAllRoomAndWorkPlaceBusyOrFree,
                (room, workplace, rentprice, orderunit) =>
                {

                    if (!result.ContainsKey(room.Id))
                    {
                        result.Add(room.Id, room);
                    }
                    AllRoomAndWorkPlaceBusyOrFreeDto crnt = result[room.Id];

                    crnt.Workplaces.Add(workplace);
                    crnt.RentPrices.Add(rentprice);
                    crnt.Orderunits.Add(orderunit);

                    return crnt;
                },

                commandType: System.Data.CommandType.StoredProcedure,
                splitOn: "id"
                );
                return result.Values.ToList();
            }
        }
        public List<AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto>();

                connection.Query<AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto, RoomDto, RentPriceDto, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto>
                (StoredProcedures.GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek,
                (allroom, room, rentprice) =>
                {

                    if (!result.ContainsKey(allroom.StartDate))
                    {
                        result.Add(allroom.StartDate, allroom);
                    }
                    AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto crnt = result[allroom.StartDate];

                    crnt.Rooms.Add(room);
                    crnt.Rentprices.Add(rentprice);


                    return crnt;
                },

                commandType: System.Data.CommandType.StoredProcedure,
                splitOn: "StartDate, Name, RegularPrice "
                );
                return result.Values.ToList();
            }
        }
    }
}