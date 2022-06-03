

namespace CoCoCoWorking.BLL.Models
{
    public class FinanceReportByCustomerModel
    {
		public int Id { get; set; }
		public string Name { get; set; }			
		public int OrderCount { get; set; }
		public double OrderSum { get; set; }
	}
}
