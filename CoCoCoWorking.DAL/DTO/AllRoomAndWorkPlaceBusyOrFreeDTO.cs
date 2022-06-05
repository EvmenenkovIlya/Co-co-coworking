using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomAndWorkPlaceBusyOrFreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkPlaceNumber { get; set; }
        public List<WorkPlaceDto> Workplaces { get; set; } = new List<WorkPlaceDto>();
        public List<RentPriceDto> RentPrices { get; set; } = new List<RentPriceDto>();
        public List<OrderUnitDto> Orderunits { get; set; } = new List<OrderUnitDto>();
    }
}
