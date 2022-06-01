using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.BLL.Models
{
    public class FinanceReportModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public double Summ { get; set; }
    }
}
