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
        private WorkplaceManager workplaceManager = new WorkplaceManager();
        private CustomerManager customerManager = new CustomerManager();
        private AdditionalServiceManager additionalServiceManager = new AdditionalServiceManager();
        private AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();
        private Singleton _instance = Singleton.GetInstance();

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

        public string GetNameForRentPriceModel(RentPriceDto r)
        {

            string name = "";
            if (r.RoomId != null)
            {
                foreach (RoomModel a in _instance.Rooms)
                {
                    if (a.Id == r.RoomId)
                    {
                        name = a.Name;
                    }
                }
            }
            else if (r.AdditionalServiceId != null)
            {
                foreach (AdditionalServiceModel a in _instance.AdditionalServices)
                {
                    if (a.Id == r.AdditionalServiceId)
                    {
                        name = a.Name;
                    }
                }
            }
            else
            {
                foreach (RoomModel a in _instance.Rooms)
                {
                    if (a.Id == r.WorkPlaceInRoomId)
                    {
                        name = $"Workplace in {a.Name}";
                    }
                }
            }
            return name;
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

        public List<WorkPlaceModel> GetAllWorkplace()
        {
            List<WorkPlaceModel> list = new List<WorkPlaceModel>();
            List<WorkPlaceDto> listDto = workplaceManager.GetAllWorkplaces();
            list = mapper.Map<List<WorkPlaceModel>>(listDto);
            return list;
        }

        public List<AdditionalServiceModel> GetAllAdditionalService()
        {
            List<AdditionalServiceModel> list = new List<AdditionalServiceModel>();
            List<AdditionalServiceDto> listDto = additionalServiceManager.GetAllAdditionalServices();
            list = mapper.Map<List<AdditionalServiceModel>>(listDto);
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
            CustomerModel customer = new CustomerModel() {FirstName = firstName, LastName = lastName, PhoneNumber = phone, Email = email};
            CustomersWithOrdersDto customerDto = mapper.Map<CustomersWithOrdersDto>(customer);
            customerManager.AddCustomer(customerDto);
        }
        public void UpdateCustomerInBase(CustomerModel customer)
        {
            
            CustomersWithOrdersDto customerDto = mapper.Map<CustomersWithOrdersDto>(customer);
            customerManager.UpdateCustomer(customerDto);
        }

        //public List<CustomerModel> WillGetTheWholeListBack(string n, List<CustomerModel> list)
        //{
        //    var d = new List<CustomerModel>();
        //    if (TextBoxNumberForSearch.Text == "")

        //        return d;

        //}
        public void AddAditionalService(AdditionalServiceModel service)
        {
            AdditionalServiceDto serviceDto = mapper.Map<AdditionalServiceDto>(service);
            additionalServiceManager.AddAdditionalService(serviceDto);
        }


        public AdditionalServiceModel GetAditionalServiceById(int serviceId)
        {
            AdditionalServiceModel additionalServiceModel = new AdditionalServiceModel();
            AdditionalServiceDto additionalServiceDto = additionalServiceManager.GetAdditionalServiceByID(serviceId);
            additionalServiceModel = mapper.Map<AdditionalServiceModel>(additionalServiceDto);
            return additionalServiceModel;
        }
        
        public void UpdateAdditionalService(AdditionalServiceModel additionalService) //на вход AdditionalServiceModel
        {
            AdditionalServiceDto additionalServiceDto = mapper.Map<AdditionalServiceDto>(additionalService);
            additionalServiceManager.UpdateAdditionalService(additionalServiceDto);
        }

        public void DeleteAdditionalService(int serviceId)
        {
            additionalServiceManager.DeleteAdditionalService(serviceId);
        }

        public void AddRoom(RoomDto room)
        {
            roomManager.AddRoom(room);
        }




    }
}
