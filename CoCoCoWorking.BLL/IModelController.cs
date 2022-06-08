using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.BLL
{
    public interface IModelController
    {
        public string GetProductName(FinanceReportDto f);
        public int GetProductCount(FinanceReportDto f);
        public TypeOfProduct GetTypeOfProduct (RoomDto r);
        public TypeOfProduct GetTypeOfProductForRentPriceModel (RentPriceDto r);
        //public TypeOfProduct GetNameForRentPriceModel(RentPriceDto r);
        public List<CustomerModel> GetCustomerWithTheMatchedNumberIsReturned(string v, List<CustomerModel> Cg);
        public bool IsRegular(CustomersWithOrdersDto customer);
        public bool IsSubscribe(CustomersWithOrdersDto customer);
        public string GetLastDate(CustomersWithOrdersDto customer);


    }
}
