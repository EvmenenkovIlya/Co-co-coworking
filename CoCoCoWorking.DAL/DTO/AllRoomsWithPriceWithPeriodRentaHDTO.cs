using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomsWithPriceWithPeriodRentaHDTO
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<RoomDTO> Rooms = new List<RoomDTO>();
        public List<RentPriceDTO> Rentprices = new List<RentPriceDTO>();
    }
}
