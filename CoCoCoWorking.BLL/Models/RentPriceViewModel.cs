using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.BLL.Models
{
    public class RentPriceViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string PeriodType { get; set; }
        public decimal? RegularPrice { get; set; }
        public decimal? ResidentPrice { get; set; }
        public decimal? FixedPrice { get; set; }
    }
}
