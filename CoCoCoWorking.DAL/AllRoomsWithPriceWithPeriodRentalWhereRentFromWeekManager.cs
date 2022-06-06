using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto>();

                connection.Query<AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto, RoomDto, RentPriceDto, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto>
                ("GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek",
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
