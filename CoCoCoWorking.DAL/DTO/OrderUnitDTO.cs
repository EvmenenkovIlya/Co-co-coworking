using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class OrderUnitDTO
    {
        public int Id { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int RoomId { get; set; }
        public int WorkPlaceId { get; set; }
        public int WorkPlaceInRoomId { get; set; }
        public int AdditionalServiceId { get; set; }
        public int OrderId { get; set; }
        public decimal? OrderUnitCost { get; set; }
        

        public override string ToString()
        {
            return $"Id={Id} StartDate={StartDate} EndDate={EndDate} RoomId={RoomId} WorkPlaceId={WorkPlaceId} WorkPlaceInRoomId={WorkPlaceInRoomId}" +
                   $"AdditionalServiceId={AdditionalServiceId} OrderId={OrderId} OrderUnitCost={OrderUnitCost}";
        }
    }
}
