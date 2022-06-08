using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDto
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public List<RentPriceDto> Rentprices { get; set; } = new List<RentPriceDto>();
    }

   
}
