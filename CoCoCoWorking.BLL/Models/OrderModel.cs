using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.BLL.Models
{
    public class OrderModel
    {
        public List<CustomerModel> Customers { get; set; }
        public int? OrderCost { get; set; }
        public string OrderStatus { get; set; }
        public string PaidDate { get; set; }
    }
}
