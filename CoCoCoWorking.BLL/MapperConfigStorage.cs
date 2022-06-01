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
                .ForMember("Name", opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
                .ForMember("Regular", opt => opt.MapFrom(c => c.IsRegular()))
                .ForMember("Subscribe", opt => opt.MapFrom(c => c.IsSubscribe()))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.GetLastDate()));

                cfg.CreateMap<RoomDTO, RoomModel>().ReverseMap()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("WorkPlaceCount", opt => opt.MapFrom(c => c.WorkPlaceNumber));

                cfg.CreateMap<WorkplaceDTO, WorkPlaceModel>().ReverseMap()
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("Number", opt => opt.MapFrom(c => c.Number));

                cfg.CreateMap<AdditionalServiceDTO, AdditionalServiceModel>().ReverseMap()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<AdditionalServiceDTO, AdditionalServiceModel>().ReverseMap()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<RentPriceDTO, RentPriceCreateModel>().ReverseMap()
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("WorkPlaceInRoomId", opt => opt.MapFrom(c => c.WorkPlaceInRoomId))
                .ForMember("AdditionalServiceId", opt => opt.MapFrom(c => c.AdditionalServiceId))
                .ForMember("PeriodType", opt => opt.MapFrom(c => c.PeriodType))
                .ForMember("RegularPrice", opt => opt.MapFrom(c => c.RegularPrice))
                .ForMember("ResidentPrice", opt => opt.MapFrom(c => c.ResidentPrice))
                .ForMember("FixedPrice", opt => opt.MapFrom(c => c.FixedPrice));
            }));
        }
    }
}
