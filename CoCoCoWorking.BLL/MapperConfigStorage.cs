using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.BLL.Models;

namespace CoCoCoWorking.BLL
{
    public class MapperConfigStorage
    {
        public MapperConfiguration config { get; private set; }

        public MapperConfigStorage()
        {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomersWithOrdersDTO, CustomerModel>()
                .ForMember("Name", opt => opt.MapFrom(c => @"{c.FirstName} {c.Name}"));
            });


        }
    }
}
