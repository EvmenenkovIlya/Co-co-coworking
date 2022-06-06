using CoCoCoWorking.BLL.Models;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;

namespace CoCoCoWorking.BLL
{
    public class Singleton
    {
        private List<CustomerModel> _customers;
        public List<CustomerModel> CustomersToEdit;
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
            _customers = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomerWhithOrderWithOrderUnit());
            AdditionalServices = mapper.Map<List<AdditionalServiceModel>>(additionalServiceManager.GetAllAdditionalServices());
            RentPrices = mapper.Map<List<RentPriceModel>>(rentPriceManager.GetAllRentPrices());
            CustomersToEdit = CopyCustomers();
        }
        public void SaveCustomerChanges()
        {
            ModelController modelController = new ModelController();
            _customers.Sort((n1, n2) => n1.Id.CompareTo(n2.Id));
            CustomersToEdit.Sort((n1, n2) => n1.Id.CompareTo(n2.Id));
            for(int i = 0; i<_customers.Count; i++)
            {
                if (CustomersToEdit[i] != _customers[i])
                {
                    modelController.UpdateCustomerInBase(CustomersToEdit[i]);
                }
            }
        }
        private List<CustomerModel> CopyCustomers()
        {
            List<CustomerModel> copyOfCustomers = new List<CustomerModel>();
            foreach(CustomerModel customer in _customers)
            {
                copyOfCustomers.Add(customer.Copy());
            }
            return copyOfCustomers;
        }


    }          
}

