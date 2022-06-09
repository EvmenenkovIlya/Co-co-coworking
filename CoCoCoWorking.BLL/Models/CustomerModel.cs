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
        //public CustomerModel(int id, string FirstName, string LastName,string PhoneNumber, string Email, bool Regular, bool Subscribe, string EndDate)
        //{
        //    id = id;
        //    FirstName=FirstName;
        //    LastName=LastName;
        //    PhoneNumber=PhoneNumber;
        //    Email=Email;
        //    Regular=Regular;
        //    Subscribe=Subscribe;
        //    EndDate=EndDate;
        //}


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