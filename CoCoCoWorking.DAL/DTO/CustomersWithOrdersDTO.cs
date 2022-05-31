using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class CustomersWithOrdersDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<OrderDTO>? Orders { get; set; } = new List<OrderDTO>();


        //public override string ToString()
        //{
        //    return $"Id={Id} FirstName={FirstName} LastName={LastName} PhoneNumber={PhoneNumber} Id1={Id1} Id2={Id2} AdditionalServiceId={AdditionalServiceId} StartDate={StartDate} EndDate={EndDate}";
        //}
    }
}
       



