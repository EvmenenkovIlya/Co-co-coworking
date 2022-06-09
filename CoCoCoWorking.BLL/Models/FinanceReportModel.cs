namespace CoCoCoWorking.BLL.Models
{
    public class FinanceReportModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public double Summ { get; set; }

        public FinanceReportModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is FinanceReportModel))
            {
                flag = false;
            }
            else
            {
                FinanceReportModel frDto = (FinanceReportModel)obj;
                if (frDto.Id != this.Id ||
                    frDto.ProductName != this.ProductName ||
                    frDto.Count != this.Count ||
                    frDto.Summ != this.Summ)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
