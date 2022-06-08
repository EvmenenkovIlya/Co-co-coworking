using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class CustomersWithOrdersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();

        public CustomersWithOrdersDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is CustomersWithOrdersDto))
            {
                flag = false;
            }
            CustomersWithOrdersDto coDto = (CustomersWithOrdersDto)obj;
            if (coDto.Id != this.Id ||
                coDto.FirstName != this.FirstName||
                coDto.LastName != this.LastName||
                coDto.PhoneNumber != this.PhoneNumber||
                coDto.Email != this.Email)
            {
                flag = false;
            }
            return flag;
        }
    }
}
       



