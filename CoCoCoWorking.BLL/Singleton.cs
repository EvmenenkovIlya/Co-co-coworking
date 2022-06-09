﻿using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL;

namespace CoCoCoWorking.BLL
{
    public class Singleton
    {
        public List<CustomerModel> CustomersToEdit;
        public List<RoomModel> Rooms { get; private set; }
        public List<RentPriceModel> RentPrices { get; private set; }
        public List<AdditionalServiceModel> AdditionalServices { get; private set; }
        public List<WorkPlaceModel> WorkPlaces { get; private set; }
        public List<OrderUnitModel> OrderUnits { get; private set; }

        public List<TypeOfProduct> typeOfProducts= new List<TypeOfProduct>() { TypeOfProduct.MiniOffice,TypeOfProduct.ConferenceHall,TypeOfProduct.MeetingRoom,TypeOfProduct.WorkPlace, TypeOfProduct.WorkPlaceFixed, TypeOfProduct.AdditionalService};
        

        private static Singleton _instance;
        
        private CustomerManager customerManager =new CustomerManager();
        private RoomManager roomManager = new RoomManager();
        private RentPriceManager rentPriceManager = new RentPriceManager();
        private AdditionalServiceManager additionalServiceManager = new AdditionalServiceManager();
        private WorkplaceManager workplaceManager = new WorkplaceManager();
        private OrderUnitManager  orderUnitManager = new OrderUnitManager();    


        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

        private Singleton()
        {            
            Rooms = mapper.Map<List<RoomModel>>(roomManager.GetAllRooms());
            CustomersToEdit = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomerWhithOrderWithOrderUnit());
            WorkPlaces = mapper.Map<List<WorkPlaceModel>>(workplaceManager.GetAllWorkplaces());
            OrderUnits = mapper.Map<List<OrderUnitModel>>(orderUnitManager.GetAllOrderUnits());
            
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
              _instance= new Singleton();
            }            
            return _instance;
        }
        public void UpdateInstance()
        {
            AdditionalServices = mapper.Map<List<AdditionalServiceModel>>(additionalServiceManager.GetAllAdditionalServices());
            RentPrices = mapper.Map<List<RentPriceModel>>(rentPriceManager.GetAllRentPrices());
            CustomersToEdit = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomerWhithOrderWithOrderUnit());
            Rooms = mapper.Map<List<RoomModel>>(roomManager.GetAllRooms());
            WorkPlaces = mapper.Map<List<WorkPlaceModel>>(workplaceManager.GetAllWorkplaces());
            OrderUnits = mapper.Map<List<OrderUnitModel>>(orderUnitManager.GetAllOrderUnits());
        }
    }          
}

