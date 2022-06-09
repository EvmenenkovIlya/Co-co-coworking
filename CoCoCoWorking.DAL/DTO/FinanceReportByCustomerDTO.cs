namespace CoCoCoWorking.DAL.DTO
{
    public class FinanceReportByCustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? OrderCount { get; set; }
        public double? OrderSum { get; set; }

        public FinanceReportByCustomerDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is FinanceReportByCustomerDto))
            {
                flag = false;
            }
            FinanceReportByCustomerDto frcDto = (FinanceReportByCustomerDto)obj;
            if (frcDto.Id != this.Id ||
                frcDto.FirstName != this.FirstName ||
                frcDto.LastName != this.LastName ||
                frcDto.PhoneNumber != this.PhoneNumber ||
                frcDto.Email != this.Email ||
                frcDto.OrderCount != this.OrderCount ||
                frcDto.OrderSum != this.OrderSum)
            {
                flag = false;
            }
            return flag;
        }
    }

}
