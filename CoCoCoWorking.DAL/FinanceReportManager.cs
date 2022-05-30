using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class FinanceReportManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<FinanceReportDTO> GetFinanceReport()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, FinanceReportDTO> result = new Dictionary<int, FinanceReportDTO>();
                connection.Query<FinanceReportDTO, RoomDTO, WorkplaceDTO, AdditionalServiceDTO, FinanceReportDTO>
                ("GetFinancialReport",
                (financereport, room, workplace, additionalservice) =>
                {
                    if (!result.ContainsKey(financereport.Id))
                    {
                        result.Add(financereport.Id, financereport);
                    }
                    FinanceReportDTO crnt = result[financereport.Id];

                    crnt.Rooms.Add(room);
                    crnt.Workplaces.Add(workplace);
                    crnt.Additionalservices.Add(additionalservice);

                    return crnt;
                },
                commandType: System.Data.CommandType.StoredProcedure,
                splitOn: "RoomId, WorkPlaceId, AdditionalServiceId,Summ"
                );
                return result.Values.ToList();


            }
        }
    }
}
