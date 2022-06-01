using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.BLL.Models
{
    public class OrderUnitModel
    {
        public string ProductName { get; set; }
        public string Name { get; set; }
        public int WorkPlaceNumber { get; set; }
        public decimal Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
