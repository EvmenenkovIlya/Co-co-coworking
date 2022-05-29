using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
        public class AllRoomAndWorkPlaceBusyOrFreeManager
    {
            public string connectionString = ServerOptions.ConnectionOption;

            public List<AllRoomAndWorkPlaceBusyOrFreeDTO> GetAllRoomAndWorkPlaceBusyOrFree()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    Dictionary<int, AllRoomAndWorkPlaceBusyOrFreeDTO> result = new Dictionary<int, AllRoomAndWorkPlaceBusyOrFreeDTO>();

                    connection.Query<AllRoomAndWorkPlaceBusyOrFreeDTO, WorkplaceDTO, RentPriceDTO,OrderUnitDTO, AllRoomAndWorkPlaceBusyOrFreeDTO>
                    ("GetAllRoomAndWorkPlaceBusyOrFree",
                    (room, workplace, rentprice,orderunit) =>
                    {

                        if (!result.ContainsKey(room.Id))
                        {
                            result.Add(room.Id, room);
                        }
                        AllRoomAndWorkPlaceBusyOrFreeDTO crnt = result[room.Id];

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
        }
}
