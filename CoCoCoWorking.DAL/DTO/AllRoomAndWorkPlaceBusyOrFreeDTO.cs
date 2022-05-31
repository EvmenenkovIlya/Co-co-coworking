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
        public string Name { get; set; }
        public int WorkPlaceNumber { get; set; }
        public List<WorkplaceDTO> Workplaces = new List<WorkplaceDTO>();
        public List <RentPriceDTO> RentPrices=new List<RentPriceDTO>();
        public List<OrderUnitDTO> Orderunits = new List<OrderUnitDTO>();    
    }
}
