using CoCoCoWorking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.Interfaces
{
    public interface IFinanceReportManager
    {
        public List<FinanceReportDto> GetFinanceReport(DateTime startDate, DateTime endDate);
        public List<FinanceReportByCustomerDto> GetFinanceReportByCustomer(DateTime startDate, DateTime endDate);
    }
}
