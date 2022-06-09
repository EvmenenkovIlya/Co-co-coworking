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
                        Type = room.Type,
                        Name = room.Name,
                        WorkPlaceNumber = room.WorkPlaceNumber
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    ); ;
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
    }
}