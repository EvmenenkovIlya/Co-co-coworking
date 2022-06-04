using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllRoomsWithPriceWithPeriodRentalWhereRentFromHourManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<AllRoomsWithPriceWithPeriodRentaHDto> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentaHDto> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentaHDto>();

                connection.Query<AllRoomsWithPriceWithPeriodRentaHDto, RoomDto, RentPriceDto, AllRoomsWithPriceWithPeriodRentaHDto>
                ("GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour",
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
    }
}
