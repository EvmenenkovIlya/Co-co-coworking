namespace CoCoCoWorking.BLL.Models
{
    public class OrderModel
    {
       // public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
        public int? OrderCost { get; set; }
        public string OrderStatus { get; set; }
        public string PaidDate { get; set; }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is OrderModel))
            {
                flag = false;
            }
            else
            {
                OrderModel orDto = (OrderModel)obj;
                if (orDto.OrderCost != this.OrderCost ||
                    orDto.OrderStatus != this.OrderStatus ||
                    orDto.PaidDate != this.PaidDate)

                {
                    flag = false;
                }
            }
            return flag;
        }
        }
}