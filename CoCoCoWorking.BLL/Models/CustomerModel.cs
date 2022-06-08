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
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}