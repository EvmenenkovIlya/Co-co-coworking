using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL
{
    public  class GetAllUnitOrdersFromSpecificOrderManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<GetAllUnitOrdersFromSpecificOrderDTO> GetAllUnitOrdersFromSpecificOrder()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, GetAllUnitOrdersFromSpecificOrderDTO> result = new Dictionary<int, GetAllUnitOrdersFromSpecificOrderDTO>();

                connection.Query<GetAllUnitOrdersFromSpecificOrderDTO, RoomDTO, WorkplaceDTO, AdditionalServiceDTO, GetAllUnitOrdersFromSpecificOrderDTO>
                    ("GetAllUnitOrdersFromSpecificOrder",
                    (orderunit, room, workplace, additionalservice) =>
                    {
                        if (!result.ContainsKey(orderunit.Id))
                        {
                            result.Add(orderunit.Id, orderunit);
                        }

                        GetAllUnitOrdersFromSpecificOrderDTO crnt = result[orderunit.Id];

                        if (room is not null)
                        {
                            crnt.Name = room.Name;
                        }

                        if (workplace is not null)
                        {
                            crnt.Number = (int)workplace.Number;
                        }

                        if (additionalservice is not null)
                        {
                            crnt.Name = additionalservice.Name;
                        }

                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                    );

                return result.Values.ToList();
            }
        }
    }
}
