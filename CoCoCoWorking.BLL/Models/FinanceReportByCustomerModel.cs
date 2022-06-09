namespace CoCoCoWorking.BLL.Models
{
    public class FinanceReportByCustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderCount { get; set; }
        public double OrderSum { get; set; }

        public FinanceReportByCustomerModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is FinanceReportByCustomerModel))
            {
                flag = false;
            }
            else
            {
                FinanceReportByCustomerModel frcDto = (FinanceReportByCustomerModel)obj;
                if (frcDto.Id != this.Id ||
                    frcDto.Name != this.Name ||
                    frcDto.OrderCount != this.OrderCount ||
                    frcDto.OrderSum != this.OrderSum)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
