using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO>();

                connection.Query<AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO, RoomDTO, RentPriceDTO, AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO>
                ("GetAllRoomsWithPriceWithPeriodRentalWhereRentFromWeek",
                (allroom, room, rentprice) =>
                {

                    if (!result.ContainsKey(allroom.StartDate))
                    {
                        result.Add(allroom.StartDate, allroom);
                    }
                    AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO crnt = result[allroom.StartDate];

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
