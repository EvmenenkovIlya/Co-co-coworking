using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
        public class AllRoomAndWorkPlaceBusyOrFreeManager
    {
            public string connectionString = ServerOptions.ConnectionOption;

            public List<AllRoomAndWorkPlaceBusyOrFreeDto> GetAllRoomAndWorkPlaceBusyOrFree()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    Dictionary<int, AllRoomAndWorkPlaceBusyOrFreeDto> result = new Dictionary<int, AllRoomAndWorkPlaceBusyOrFreeDto>();

                    connection.Query<AllRoomAndWorkPlaceBusyOrFreeDto, WorkPlaceDto, RentPriceDto,OrderUnitDto, AllRoomAndWorkPlaceBusyOrFreeDto>
                    ("GetAllRoomAndWorkPlaceBusyOrFree",
                    (room, workplace, rentprice,orderunit) =>
                    {

                        if (!result.ContainsKey(room.Id))
                        {
                            result.Add(room.Id, room);
                        }
                        AllRoomAndWorkPlaceBusyOrFreeDto crnt = result[room.Id];

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
