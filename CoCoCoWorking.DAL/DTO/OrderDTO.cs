using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? OrderCost { get; set; }
        public string OrderStatus { get; set; }
        public string PaidDate { get; set; }
        public List<OrderUnitDto> OrderUnits { get; set; } = new List<OrderUnitDto>();
    }
}
