using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;

namespace CoCoCoWorking.BLL
{
    public class Singleton
    {
        public List<CustomerModel> Customers { get; private set; }
        public List<RoomModel> Rooms { get; private set; }
        public List<RentPriceModel> RentPrices { get; private set; }
        public List<AdditionalServiceModel> AdditionalServices { get; private set; }

        private static Singleton _instance;
        
        private AllCustomerWhithOrderWithOrderUnitManager customerManager =new AllCustomerWhithOrderWithOrderUnitManager();
        private RoomManager roomManager = new RoomManager();
        private RentPriceManager rentPriceManager = new RentPriceManager();
        private AdditionalServiceManager additionalServiceManager = new AdditionalServiceManager();
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

        private Singleton()
        {
            Customers = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomers());
            Rooms = mapper.Map<List<RoomModel>>(roomManager.GetAllRooms());
            
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
            Reports = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomerWhithOrderWithOrderUnit());
            AdditionalServices = mapper.Map<List<AdditionalServiceModel>>(additionalServiceManager.GetAllAdditionalServices());
            RentPrices = mapper.Map<List<RentPriceModel>>(rentPriceManager.GetAllRentPrices());
        }

    }          
}

