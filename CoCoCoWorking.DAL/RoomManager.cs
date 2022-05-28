using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class RoomManager
    {
        public string connectionString = ServerOptions.ConnectionOption;
        public List<RoomDTO> GetAllRooms()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<RoomDTO>(
                    StoredProcedures.Room_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public RoomDTO GetRoomByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<RoomDTO>(
                    StoredProcedures.Room_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void AddRoom(string name, int workPlaceNumber)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle(
                    StoredProcedures.Room_Add,
                    param: new
                    {
                        Name = name,
                        WorkPlaceNumber = workPlaceNumber
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void UpdateRoom(int id, string name, int workPlaceNumber)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingleOrDefault(
                    StoredProcedures.Room_Update,
                    param: new
                    {
                        id = id,
                        Name = name,
                        WorkPlaceNumber = workPlaceNumber
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}