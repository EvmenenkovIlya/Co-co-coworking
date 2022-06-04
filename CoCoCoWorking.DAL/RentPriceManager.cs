using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class RentPriceManager
    {

        public string connectionString = ServerOptions.ConnectionOption;
        public List<RentPriceDto> GetAllRentPrices()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<RentPriceDto>(
                    StoredProcedures.RentPrice_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public RentPriceDto GetRentPriceByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<RentPriceDto>(
                    StoredProcedures.RentPrice_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddRentPrice(RentPriceDto rentPrice)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingle(
                    StoredProcedures.RentPrice_Add,
                     param: new
                     {
                         roomId = rentPrice.RoomId,
                         workPlaceInRoomId = rentPrice.WorkPlaceInRoomId,
                         additionalServiceId = rentPrice.AdditionalServiceId,
                         periodType = rentPrice.PeriodType,
                         regularPrice = rentPrice.RegularPrice,
                         residentPrice = rentPrice.ResidentPrice,
                         fixedPrice = rentPrice.FixedPrice
                     },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateRentPrice(RentPriceDto rentPrice)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingleOrDefault(
                    StoredProcedures.RentPrice_Update,
                    param: new
                    {
                        id = rentPrice.Id,
                        roomId = rentPrice.RoomId,
                        workPlaceInRoomId = rentPrice.WorkPlaceInRoomId,
                        additionalServiceId = rentPrice.AdditionalServiceId,
                        periodType = rentPrice.PeriodType,
                        regularPrice = rentPrice.RegularPrice,
                        residentPrice = rentPrice.ResidentPrice,
                        fixedPrice = rentPrice.FixedPrice
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteRentPrice(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingleOrDefault<RentPriceDto>(
                    StoredProcedures.RentPrice_SoftDelete,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

    }
}
