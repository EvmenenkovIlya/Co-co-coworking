using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class OrderUnitDto
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public int OrderId { get; set; }
        public decimal? OrderUnitCost { get; set; }

        public OrderUnitDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is OrderUnitDto))
            {
                flag = false;
            }
            OrderUnitDto oruDto = (OrderUnitDto)obj;
            if (oruDto.Id != this.Id ||
               oruDto.StartDate != this.StartDate ||
               oruDto.EndDate != this.EndDate||
               oruDto.RoomId != this.RoomId ||
               oruDto.WorkPlaceId != this.WorkPlaceId||
               oruDto.WorkPlaceInRoomId!=this.WorkPlaceInRoomId||
               oruDto.AdditionalServiceId!=this.AdditionalServiceId||
               oruDto.OrderId!=this.OrderId||
               oruDto.OrderUnitCost!=this.OrderUnitCost)
            {
                flag = false;
            }
            return flag;
        }
    }
}
