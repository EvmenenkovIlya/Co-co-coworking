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
        public CustomerModel Copy()
        {
            CustomerModel copy = new CustomerModel() 
            { 
            Id = this.Id, FirstName = this.FirstName, LastName = this.LastName, 
            Email = this.Email, PhoneNumber = this.PhoneNumber, EndDate = this.EndDate, 
            Regular = this.Regular, Subscribe = this.Subscribe
            };
            return copy;
        }     
    }
}