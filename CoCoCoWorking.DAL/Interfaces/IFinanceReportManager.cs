using CoCoCoWorking.DAL.DTO;

namespace CoCoCoWorking.DAL.Interfaces
{
    public interface IFinanceReportManager
    {
        public List<FinanceReportDto> GetFinanceReport(DateTime startDate, DateTime endDate);
        public List<FinanceReportByCustomerDto> GetFinanceReportByCustomer(DateTime startDate, DateTime endDate);
    }
}
