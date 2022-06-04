using CoCoCoWorking.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;

namespace CoCoCoWorking.BLL
{
    public class Singleton
    {
        public List<CustomerModel> Reports { get; private set; }
        public List<RoomModel> Rooms { get; private set; }
        public List<RentPriceModel> RentPrices { get; private set; }
        public List<AdditionalServiceModel> AdditionalServices { get; private set; }

        private static Singleton _instance;
        
        private CustomerManager customerManager=new CustomerManager();
        private RoomManager roomManager = new RoomManager();
        private RentPriceManager rentPriceManager = new RentPriceManager();
        private AdditionalServiceManager additionalServiceManager = new AdditionalServiceManager();
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

        private Singleton()
        {
            Reports = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomers());
            Rooms = mapper.Map<List<RoomModel>>(roomManager.GetAllRooms());
            RentPrices = mapper.Map<List<RentPriceModel>>(rentPriceManager.GetAllRentPrices());
            AdditionalServices = mapper.Map<List<AdditionalServiceModel>>(additionalServiceManager.GetAllAdditionalServices());
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
              _instance= new Singleton();
            }            
    
            return _instance;
        }
    }
   

    

    
}

