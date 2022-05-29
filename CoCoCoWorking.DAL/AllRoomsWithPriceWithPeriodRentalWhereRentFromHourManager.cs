using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllRoomsWithPriceWithPeriodRentalWhereRentFromHourManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<AllRoomsWithPriceWithPeriodRentaHDTO> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentaHDTO> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentaHDTO>();

                connection.Query<AllRoomsWithPriceWithPeriodRentaHDTO, RoomDTO, RentPriceDTO, AllRoomsWithPriceWithPeriodRentaHDTO>
                ("GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour",
                (allroom, room, rentprice) =>
                {

                    if (!result.ContainsKey(allroom.StartDate))
                    {
                        result.Add(allroom.StartDate, allroom);
                    }
                    AllRoomsWithPriceWithPeriodRentaHDTO crnt = result[allroom.StartDate];

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
