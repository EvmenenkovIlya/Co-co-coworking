using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.BLL.Models;


namespace CoCoCoWorking.BLL
{
    public class ModelController
    {
        private FinanceReportManager financeReportManager = new FinanceReportManager();
        private RoomManager roomManager = new RoomManager();
        private OrderUnitManager orderUnitManager = new OrderUnitManager();
        private AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
       // private Singleton _instance = Singleton.GetInstance();

        public string GetProductName(FinanceReportDto f)
        {
            string s = "";
            if (f.RoomName != null)
            {
                s = f.RoomName;
            }
            else if (f.AdditionalServiceName != null)
            {
                s = f.AdditionalServiceName;
            }
            else
            {
                s = "WorkPlaces";
            }
            return s;
        }

        public int GetProductCount(FinanceReportDto f)
        {
            int i = 0;
            if (f.RoomCount != 0)
            {
                i = (int)f.RoomCount;
            }
            else if (f.AdditionalServiceCount != 0)
            {
                i = (int)f.AdditionalServiceCount;
            }
            else if (f.WorkPlaceCount != 0)
            {
                i = (int)f.WorkPlaceCount;
            }
            return i;
        }

        public TypeOfProduct GetTypeOfProduct(RoomDto r)
        {
            TypeOfProduct type = (TypeOfProduct)Enum.Parse(typeof(TypeOfProduct), r.Type);

            return type;
        }

        public TypeOfProduct GetTypeOfProductForRentPriceModel(RentPriceDto r)
        {
            var _instance = Singleton.GetInstance();
            TypeOfProduct type = new TypeOfProduct();
            if (r.RoomId != null)
            {
                foreach (RoomModel a in _instance.Rooms)
                {
                    if (a.Id == r.RoomId)
                    {
                        type = a.Type;
                    }
                }
            }
            else if (r.AdditionalServiceId != null)
            {
                type = TypeOfProduct.AdditionalService;
            }
            else
            {
                type = TypeOfProduct.WorkPlace;
            }
            return type;
        }

        public TypeOfProduct GetNameForRentPriceModel(RentPriceDto r)
        {
            var _instance = Singleton.GetInstance();
            TypeOfProduct type = new TypeOfProduct();
            if (r.RoomId != null)
            {
                foreach (RoomModel a in _instance.Rooms)
                {
                    if (a.Id == r.RoomId)
                    {
                        type = a.Type;
                    }
                }
            }
            else if (r.AdditionalServiceId != null)
            {
                type = TypeOfProduct.AdditionalService;
            }
            else
            {
                type = TypeOfProduct.WorkPlace;
            }
            return type;
        }

        public TypeOfPeriod GetTypeOfPeriod (RentPriceDto r)
        {
            TypeOfPeriod type = (TypeOfPeriod)Enum.Parse(typeof(TypeOfPeriod), r.PeriodType);

            return type;
        }

        public List<FinanceReportModel> GetFinanceReportModels(DateTime startDate, DateTime endDate)
        {
            List<FinanceReportDto> listDto = financeReportManager.GetFinanceReport(startDate, endDate);
            List<FinanceReportModel> list = mapper.Map<List<FinanceReportModel>>(listDto);
            return list;
        }

        public List<FinanceReportByCustomerModel> GetFinanceReportByCustomerModels(DateTime startDate, DateTime endDate)
        {
            List<FinanceReportByCustomerDto> listDto = financeReportManager.GetFinanceReportByCustomer(startDate, endDate);
            List<FinanceReportByCustomerModel> list = mapper.Map<List<FinanceReportByCustomerModel>>(listDto);
            return list;
        }

        public List<RoomModel> GetAllRoom()
        {           
            List<RoomDto> listDto = roomManager.GetAllRooms();
            List<RoomModel>  list = mapper.Map<List<RoomModel>>(listDto);
            return list;
        }
        public List<OrderUnitModel> GetAllOrderUnit()
        {
            List<OrderUnitDto> listDto = orderUnitManager.GetAllOrderUnits();
            List<OrderUnitModel> list = mapper.Map<List<OrderUnitModel>>(listDto);
            return list;
        }

        public List<CustomerModel> GetCustomerWithTheMatchedNumberIsReturned(string v, List<CustomerModel> Cg)
        {
            var d = new List<CustomerModel>();          
            foreach (var customermodel in Cg)
            {
                if (customermodel.PhoneNumber.Contains(v))
                {
                    d.Add(customermodel);
                }               
            }
            return d;
        }
        public bool IsRegular(CustomersWithOrdersDto customer)
        {
            if (customer.Orders == null || customer.Orders.Count == 0)
            {
                return false;
            }
            foreach (OrderDto order in customer.Orders)
            {
                if (order != null)
                {
                    foreach (OrderUnitDto orderUnit in order.OrderUnits!)
                    {
                        if ((DateTime.Parse(orderUnit.EndDate!) - DateTime.Parse(orderUnit.EndDate!)).Days > 30)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool IsSubscribe(CustomersWithOrdersDto customer)
        {
            if (customer.Orders == null || customer.Orders.Count == 0)
            {
                return false;
            }
            foreach (OrderDto order in customer.Orders)
            {
                if (order != null)
                {
                    foreach (OrderUnitDto orderUnit in order.OrderUnits!)
                    {
                        if (orderUnit.AdditionalServiceId == 1 && DateTime.Parse(orderUnit.EndDate!) > DateTime.Now.Date)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public string GetLastDate(CustomersWithOrdersDto customer)
        {
            DateTime lastDate = new DateTime();
            if (customer.Orders != null)
            {
                foreach (OrderDto order in customer.Orders)
                {
                    if (order != null)
                    {
                        foreach (OrderUnitDto orderUnit in order.OrderUnits!)
                        {
                            DateTime crnt = DateTime.Parse(orderUnit.EndDate);
                            if (crnt > lastDate)
                            {
                                lastDate = crnt;
                            }
                        }
                    }
                }
            }
            if (lastDate == new DateTime())
            {
                return "No orders";
            }
            return lastDate.ToString();
        }
        public void AddCustomerToBase(string firstName, string lastName, string phone, string email)
        {
            CustomerManager customerManager = new CustomerManager();
            CustomerModel customer = new CustomerModel() {FirstName = firstName, LastName = lastName, PhoneNumber = phone, Email = email};
            CustomersWithOrdersDto customerDto = mapper.Map<CustomersWithOrdersDto>(customer);
            customerManager.AddCustomer(customerDto);
        }
        public void UpdateCustomerInBase(int id, string firstName, string lastName, string phone, string email)
        {
            CustomerManager customerManager = new CustomerManager();
            CustomerModel customer = new CustomerModel() { Id = id, FirstName = firstName, LastName=lastName, PhoneNumber=phone, Email=email};
            CustomersWithOrdersDto customerDto = mapper.Map<CustomersWithOrdersDto>(customer);
            customerManager.UpdateCustomer(customerDto);
        }
    }
}
