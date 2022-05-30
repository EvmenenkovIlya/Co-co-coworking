using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomAndWorkPlaceBusyOrFreeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? WorkPlaceNumber { get; set; }
        public List<WorkplaceDTO>? Workplaces { get; set; }
        public List <RentPriceDTO>? RentPrices { get; set; }
        public List<OrderUnitDTO>? Orderunits { get; set; }
    }
}
