using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllAdditionalServiceDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Count { get; set; }
        public List<OrderUnitDTO>? Orderunits { get; set; } 
        public List<RentPriceDTO>? Rentprices { get; set; }
    }
}
