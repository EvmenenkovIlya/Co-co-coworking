using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHourManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<AllRoomsWithPriceWithPeriodRentaDTO> GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<string, AllRoomsWithPriceWithPeriodRentaDTO> result = new Dictionary<string, AllRoomsWithPriceWithPeriodRentaDTO>();

                connection.Query<AllRoomsWithPriceWithPeriodRentaDTO, RoomDTO, RentPriceDTO, AllRoomsWithPriceWithPeriodRentaDTO>
                ("GetAllRoomsWithPriceWithPeriodRentalWhereRentFromHour",
                (allroom, room, rentprice) =>
                {

                    if (!result.ContainsKey(allroom.StartDate))
                    {
                        result.Add(allroom.StartDate, allroom);
                    }
                    AllRoomsWithPriceWithPeriodRentaDTO crnt = result[allroom.StartDate];

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
