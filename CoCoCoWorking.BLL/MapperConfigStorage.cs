﻿using AutoMapper;
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
        private static Mapper _instance;
        
        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitMapperConfigStorage();               
            return _instance;
        }
        

        private static void InitMapperConfigStorage()
        {
            _instance =new Mapper(new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<CustomersWithOrdersDTO, CustomerModel>()
                .ForMember("Name", opt => opt.MapFrom(c => @"{c.FirstName} {c.Name}"));

                cfg.CreateMap<RoomDTO, RoomModel>().ReverseMap();

                cfg.CreateMap<WorkplaceDTO, WorkPlaceModel>().ReverseMap();

                cfg.CreateMap<AdditionalServiceDTO, AdditionalServiceModel>().ReverseMap();
                
            }));


        }
    }
}
