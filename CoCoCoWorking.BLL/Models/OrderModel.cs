namespace CoCoCoWorking.BLL.Models
{
    public class OrderModel
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? OrderCost { get; set; }
        public string OrderStatus { get; set; }
        public string PaidDate { get; set; }
        public List<OrderUnitModel> OrderUnits { get; set; } = new List<OrderUnitModel>();



        //// public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
        // public int? OrderCost { get; set; }
        // public string OrderStatus { get; set; }
        // public string PaidDate { get; set; }


    }
}
