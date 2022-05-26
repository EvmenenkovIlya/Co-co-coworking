using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class RentPriceManager
    {

        public string connectionString = @"Server=DESKTOP-U9ABOQU\SQLEXPRESS;Database=CoCoCoworking.DB;Trusted_Connection=True;";
        public List<RentPriceDTO> GetAllRentPrice()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<RentPriceDTO>(
                    StoredProcedures.RentPrice_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public RentPriceDTO GetRentPriceByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<RentPriceDTO>(
                    StoredProcedures.RentPrice_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddRentPrice(int? roomId, int? workPlaceInRoomId, int? additionalServiceId, string periodType,
                                               decimal regularPrice, decimal? residentPrice, decimal? fixedPrice)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingle<RentPriceDTO>(
                    StoredProcedures.RentPrice_Add,
                     param: new
                     {
                         roomId = roomId,
                         workPlaceInRoomId = workPlaceInRoomId,
                         additionalServiceId = additionalServiceId,
                         periodType = periodType,
                         regularPrice = regularPrice,
                         residentPrice = residentPrice,
                         fixedPrice = fixedPrice
                     },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateRentPrice(int id, int? roomId, int? workPlaceInRoomId, int? additionalServiceId, string periodType,
                                                          decimal regularPrice, decimal? residentPrice, decimal? fixedPrice)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingleOrDefault <RentPriceDTO>(
                    StoredProcedures.RentPrice_Update,
                    param: new
                    {
                        id = id,
                        roomId = roomId,
                        workPlaceInRoomId = workPlaceInRoomId,
                        additionalServiceId = additionalServiceId,
                        periodType = periodType,
                        regularPrice = regularPrice,
                        residentPrice = residentPrice,
                        fixedPrice = fixedPrice
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteRentPrice(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingleOrDefault<RentPriceDTO>(
                    StoredProcedures.RentPrice_SoftDelete,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

    }
}
