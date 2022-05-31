using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class CustomersWithOrdersDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<OrderDTO>? Orders { get; set; } = new List<OrderDTO>();
        public bool IsRegular()
        {
            if (Orders==null || Orders.Count==0)
            {
                return false;
            }
            foreach (OrderDTO order in Orders)
            {
                foreach (OrderUnitDTO orderUnit in order.Orderunits!)
                { 
                    if ((DateTime.Parse(orderUnit.EndDate!) - DateTime.Parse(orderUnit.EndDate!)).Days > 30)
                    {
                        return true;
                    }    
                }
            }
            return false;
        }
        public bool IsSubscribe()
        {
            if (Orders == null || Orders.Count == 0)
            {
                return false;
            }
            foreach (OrderDTO order in Orders)
            {
                foreach (OrderUnitDTO orderUnit in order.Orderunits!)
                {
                    if (orderUnit.AdditionalServiceId == 1 && DateTime.Parse(orderUnit.EndDate!) > DateTime.Now.Date)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetLastDate()
        {
            DateTime lastDate = DateTime.Now.Date;
            foreach (OrderDTO order in Orders)
            {
                foreach (OrderUnitDTO orderUnit in order.Orderunits!)
                {
                    DateTime crnt = DateTime.Parse(orderUnit.EndDate);
                    if (crnt > lastDate)
                    {
                        crnt = lastDate;
                    }
                }
            }
            return lastDate.ToString();
        }
        //public override string ToString()
        //{
        //    return $"Id={Id} FirstName={FirstName} LastName={LastName} PhoneNumber={PhoneNumber} Id1={Id1} Id2={Id2} AdditionalServiceId={AdditionalServiceId} StartDate={StartDate} EndDate={EndDate}";
        //}
    }
}
       



