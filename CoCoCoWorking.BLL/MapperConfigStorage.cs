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
        private static Mapper _instance;
        
        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitMapperConfigStorage();               
            return _instance;
        }
        
        private static ModelController modelController = new ModelController();

        private static void InitMapperConfigStorage()
        {
            _instance = new Mapper(new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<CustomersWithOrdersDTO, CustomerModel>()
                .ForMember("Name", opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
                .ForMember("Regular", opt => opt.MapFrom(c => c.IsRegular()))
                .ForMember("Subscribe", opt => opt.MapFrom(c => c.IsSubscribe()))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.GetLastDate()));

                cfg.CreateMap<RoomDTO, RoomModel>().ReverseMap()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("WorkPlaceNumber", opt => opt.MapFrom(c => c.WorkPlaceNumber));

                cfg.CreateMap<WorkplaceDTO, WorkPlaceModel>().ReverseMap()
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("Number", opt => opt.MapFrom(c => c.Number));

                cfg.CreateMap<AdditionalServiceDTO, AdditionalServiceModel>().ReverseMap()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<OrderUnitDTO, OrderUnitModel>();
/*                .ForMember("ProductName", opt => opt.MapFrom(c => c.AdditionalServiceId)) //Id, but should be name
                .ForMember("Price", opt => opt.MapFrom(c => c.OrderUnitCost));*/


                cfg.CreateMap<RentPriceDTO, RentPriceCreateModel>().ReverseMap()
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("WorkPlaceInRoomId", opt => opt.MapFrom(c => c.WorkPlaceInRoomId))
                .ForMember("AdditionalServiceId", opt => opt.MapFrom(c => c.AdditionalServiceId))
                .ForMember("PeriodType", opt => opt.MapFrom(c => c.PeriodType))
                .ForMember("RegularPrice", opt => opt.MapFrom(c => c.RegularPrice))
                .ForMember("ResidentPrice", opt => opt.MapFrom(c => c.ResidentPrice))
                .ForMember("FixedPrice", opt => opt.MapFrom(c => c.FixedPrice));

                cfg.CreateMap<FinanceReportDTO, FinanceReportModel>()
                .ForMember("ProductName", opt => opt.MapFrom(c => modelController.GetProductName(c)))
                .ForMember("Count", opt => opt.MapFrom(c => modelController.GetProductCount(c)))
                .ForMember("Summ", opt => opt.MapFrom(c => c.Summ));


                //cfg.CreateMap<CustomersWithOrdersDTO, OrderModel>()
                //.ForMember("Name", opt => opt.MapFrom(c => $"{c.LastName}{c.FirstName}{c.PhoneNumber}"));


                //cfg.CreateMap<CustomersWithOrdersDTO, OrderModel>()
                //.ForMember("Name", opt => opt.MapFrom(c => $"{c.LastName}{c.FirstName}{c.PhoneNumber}"));

                cfg.CreateMap<OrderDTO, OrderModel>()
                .ForMember("OrderCost", opt => opt.MapFrom(c => c.OrderCost))
                .ForMember("OrderStatus", opt => opt.MapFrom(c => c.OrderStatus))
                .ForMember("PaidDate", opt => opt.MapFrom(c => c.PaidDate));

                cfg.CreateMap<FinanceReportByCustomerDTO, FinanceReportByCustomerModel>()
                .ForMember("Name", opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
                .ForMember("OrderCount", opt => opt.MapFrom(c => c.OrderCount))
                .ForMember("OrderSum", opt => opt.MapFrom(c => c.OrderSum));

                cfg.CreateMap<OrderUnitDTO, OrderUnitModel>()
                .ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.EndDate))
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("WorkPlaceId", opt => opt.MapFrom(c => c.WorkPlaceId))
                .ForMember("WorkPlaceInRoomId", opt => opt.MapFrom(c => c.WorkPlaceInRoomId))
                .ForMember("AdditionalServiceId", opt => opt.MapFrom(c => c.AdditionalServiceId))
                .ForMember("OrderId", opt => opt.MapFrom(c => c.OrderId))
                .ForMember("OrderUnitCost", opt => opt.MapFrom(c => c.OrderUnitCost));


                cfg.CreateMap<GetAllUnitOrdersFromSpecificOrderDTO, GetAllUnitOrdersFromSpecificOrderModel>()
                .ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.EndDate))
                .ForMember("Name", opt => opt.MapFrom(c => $"{c.RoomName}{c.ServiceName}"))
                .ForMember("Number", opt => opt.MapFrom(c => c.Number));
            }));
        }
    }
}
