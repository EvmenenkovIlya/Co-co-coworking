namespace CoCoCoWorking.BLL.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Regular { get; set; }
        public bool Subscribe { get; set; }
        public string EndDate { get; set; }

        public CustomerModel()
        {

        }
        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is CustomerModel))
            {
                flag = false;
            }

            CustomerModel oruDto = (CustomerModel)obj;
            if (oruDto.Id != this.Id ||
               oruDto.FirstName != this.FirstName ||
               oruDto.LastName != this.LastName ||
               oruDto.PhoneNumber != this.PhoneNumber ||
               oruDto.Email != this.Email ||
               oruDto.Regular != this.Regular ||
               oruDto.Subscribe != this.Subscribe ||
               oruDto.EndDate != this.EndDate )
            {
                flag = false;
            }
            return flag;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}