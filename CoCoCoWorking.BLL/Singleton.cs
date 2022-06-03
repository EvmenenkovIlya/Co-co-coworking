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

        private static Singleton _instance;
        
        private CustomerManager customerManager=new CustomerManager();
        AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

        private Singleton()
        {
            Reports = new List<CustomerModel>();
            Reports = mapper.Map<List<CustomerModel>>(customerManager.GetAllCustomers());
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

