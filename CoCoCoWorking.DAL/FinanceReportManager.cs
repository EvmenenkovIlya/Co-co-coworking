using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class FinanceReportManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<FinanceReportDBO> GetFinanceReport()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, FinanceReportDBO> result = new Dictionary<int, FinanceReportDBO>();
                connection.Query<FinanceReportDBO, RoomDTO, WorkplaceDTO, AdditionalServiceDTO, FinanceReportDBO>
                ("GetFinancialReport",
                (financereport, room, workplace, additionalservice) =>
                {
                    if (!result.ContainsKey(financereport.Id))
                    {
                        result.Add(financereport.Id, financereport);
                    }
                    FinanceReportDBO crnt = result[financereport.Id];

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
