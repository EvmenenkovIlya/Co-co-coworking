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
        public string GetTypeOfProduct(RoomModel r);
        public TypeOfProduct GetTypeOfProductForRentPriceModel (RentPriceDto r);
        public string GetNameForRentPriceModel(RentPriceDto r);
        public List<FinanceReportModel> GetFinanceReportModels(DateTime startDate, DateTime endDate);
        public List<FinanceReportByCustomerModel> GetFinanceReportByCustomerModels(DateTime startDate, DateTime endDate);
        public List<RoomModel> GetAllRoom();
        public List<WorkPlaceModel> GetAllWorkplace();
        public List<AdditionalServiceModel> GetAllAdditionalService();
        public List<CustomerModel> GetCustomerWithTheMatchedNumberIsReturned(string v, List<CustomerModel> Cg);
        public bool IsRegular(CustomersWithOrdersDto customer);
        public bool IsSubscribe(CustomersWithOrdersDto customer);
        public string GetLastDate(CustomersWithOrdersDto customer);
        public void AddCustomerToBase(string firstName, string lastName, string phone, string email);
        public void UpdateCustomerInBase(CustomerModel customer);
        public void AddAditionalService(AdditionalServiceModel service);
        public decimal GetSumOrderUnits(List<OrderUnitModel> unitOrders);
        public string AddOrderInBase(OrderModel order);
        public AdditionalServiceModel GetAditionalServiceById(int serviceId);
        public void UpdateAdditionalService(AdditionalServiceModel additionalService);
        public List<OrderModel> GetOrderByCustomerID(int id);
        public void AddUnitOrdertoBase(OrderUnitModel orderUnit);
        public void DeleteAdditionalService(int serviceId);
        public void AddRoom(RoomModel room);

    }
}
