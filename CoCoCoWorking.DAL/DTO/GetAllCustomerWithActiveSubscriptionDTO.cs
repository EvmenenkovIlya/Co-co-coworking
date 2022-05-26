using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class GetAllCustomerWithActiveSubscriptionDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public int? AdditionalServiceId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public override string ToString()
        {
            return $"Id={Id} FirstName={FirstName} LastName={LastName} PhoneNumber={PhoneNumber} Id1={Id1} Id2={Id2} AdditionalServiceId={AdditionalServiceId} StartDate={StartDate} EndDate={EndDate}";
        }
    }
}
       



