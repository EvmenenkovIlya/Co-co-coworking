using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllAdditionalServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public List<OrderUnitDto> Orderunits { get; set; } = new List<OrderUnitDto>();
        public List<RentPriceDto> Rentprices { get; set; } = new List<RentPriceDto>();

        public AllAdditionalServiceDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AllAdditionalServiceDto))
            {
                flag = false;
            }
            AllAdditionalServiceDto adDto = (AllAdditionalServiceDto)obj;
            if (adDto.Id != this.Id ||
                adDto.Name != this.Name ||
                adDto.Count != this.Count)
            {
                flag = false;
            }
            return flag;
        }
    }
}
