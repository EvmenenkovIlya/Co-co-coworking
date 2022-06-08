using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class RentPriceDto
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public string PeriodType { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? ResidentPrice { get; set; }
        public decimal? FixedPrice { get; set; }
        public bool IsDeleted { get; set; }

        public RentPriceDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is RentPriceDto))
            {
                flag = false;
            }
            RentPriceDto rpDto = (RentPriceDto)obj;
            if (rpDto.Id != this.Id ||
               rpDto.RoomId != this.RoomId ||
               rpDto.WorkPlaceInRoomId != this.WorkPlaceInRoomId ||
               rpDto.AdditionalServiceId != this.AdditionalServiceId ||
               rpDto.PeriodType != this.PeriodType ||
               rpDto.RegularPrice != this.RegularPrice ||
               rpDto.ResidentPrice != this.ResidentPrice||
               rpDto.FixedPrice!=this.FixedPrice
               )
            {
                flag = false;
            }
            return flag;
        }
    }
}
