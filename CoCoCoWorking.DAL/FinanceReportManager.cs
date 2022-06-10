using CoCoCoWorking.DAL.DTO;

using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class FinanceReportManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<FinanceReportDto> GetFinanceReport(DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<FinanceReportDto>
                    (StoredProcedures.GetFinanceReport,
                    param: new { StartDate = startDate, EndDate = endDate},
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public List<FinanceReportByCustomerDto> GetFinanceReportByCustomer(DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<FinanceReportByCustomerDto>
                    (StoredProcedures.GetFinanceReportByCustomer,
                    param: new { StartDate = startDate, EndDate = endDate },
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }
    }
}
