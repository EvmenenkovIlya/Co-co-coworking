using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.DAL.Interfaces;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class FinanceReportManager : IFinanceReportManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        private IFinanceReportManager _financeReportManager;

        public FinanceReportManager()
        {

        }

        public FinanceReportManager(IFinanceReportManager financeReport)
        {
            _financeReportManager = financeReport;
        }

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
