using AutoMapper;
using CoCoCoWorking.BLL;
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
                cfg.CreateMap<CustomersWithOrdersDto, CustomerModel>()
                .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                .ForMember("FirstName", opt => opt.MapFrom(c => c.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(c =>  c.LastName))
                .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                .ForMember("Email", opt => opt.MapFrom(c => c.Email))
                .ForMember("Regular", opt => opt.MapFrom(c => modelController.IsRegular(c)))
                .ForMember("Subscribe", opt => opt.MapFrom(c => modelController.IsSubscribe(c)))
                .ForMember("EndDate", opt => opt.MapFrom(c => modelController.GetLastDate(c)));

                cfg.CreateMap<CustomerModel, CustomersWithOrdersDto>()
                .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                .ForMember("FirstName", opt => opt.MapFrom(c => c.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(c => c.LastName))
                .ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
                .ForMember("Email", opt => opt.MapFrom(c => c.Email));

                cfg.CreateMap<RoomDto, RoomModel>().ReverseMap()
                .ForMember("Type", opt => opt.MapFrom(c => modelController.GetTypeOfProduct(c)))
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("WorkPlaceNumber", opt => opt.MapFrom(c => c.WorkPlaceNumber));

                cfg.CreateMap<WorkPlaceDto, WorkPlaceModel>().ReverseMap()
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("Number", opt => opt.MapFrom(c => c.Number));

                cfg.CreateMap<AdditionalServiceDto, AdditionalServiceModel>().ReverseMap()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("Count", opt => opt.MapFrom(c => c.Count));

                //cfg.CreateMap<AdditionalServiceDto, AdditionalServiceModel>().ReverseMap() // это м.б. AllAdditionalServiceDto?
                //.ForMember("Name", opt => opt.MapFrom(c => c.Name));
                //cfg.CreateMap<OrderUnitDto, OrderUnitModel>();

                //cfg.CreateMap<RentPriceDto, RentPriceCreateModel>().ReverseMap();
                cfg.CreateMap<RentPriceDto, RentPriceModel>()
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("WorkPlaceInRoomId", opt => opt.MapFrom(c => c.WorkPlaceInRoomId))
                .ForMember("AdditionalServiceId", opt => opt.MapFrom(c => c.AdditionalServiceId))
                .ForMember("Type", opt => opt.MapFrom(c => modelController.GetTypeOfProductForRentPriceModel(c)))
                .ForMember("Name", opt => opt.MapFrom(c => modelController.GetNameForRentPriceModel(c)))
                .ForMember("PeriodType", opt => opt.MapFrom(c => modelController.GetTypeOfPeriod(c)))
                .ForMember("RegularPrice", opt => opt.MapFrom(c => c.RegularPrice))
                .ForMember("ResidentPrice", opt => opt.MapFrom(c => c.ResidentPrice))
                .ForMember("FixedPrice", opt => opt.MapFrom(c => c.FixedPrice));

                cfg.CreateMap<FinanceReportDto, FinanceReportModel>()
                .ForMember("ProductName", opt => opt.MapFrom(c => modelController.GetProductName(c)))
                .ForMember("Count", opt => opt.MapFrom(c => modelController.GetProductCount(c)))
                .ForMember("Summ", opt => opt.MapFrom(c => c.Summ));


                //cfg.CreateMap<CustomersWithOrdersDTO, OrderModel>()
                //.ForMember("Name", opt => opt.MapFrom(c => $"{c.LastName}{c.FirstName}{c.PhoneNumber}"));


                //cfg.CreateMap<CustomersWithOrdersDTO, OrderModel>()
                //.ForMember("Name", opt => opt.MapFrom(c => $"{c.LastName}{c.FirstName}{c.PhoneNumber}"));

                cfg.CreateMap<OrderDto, OrderModel>().ReverseMap()
               // cfg.CreateMap<OrderModel, OrderDto>()
                .ForMember("OrderCost", opt => opt.MapFrom(c => c.OrderCost))
                .ForMember("OrderStatus", opt => opt.MapFrom(c => c.OrderStatus))
                .ForMember("PaidDate", opt => opt.MapFrom(c => c.PaidDate));


                cfg.CreateMap<FinanceReportByCustomerDto, FinanceReportByCustomerModel>()
                .ForMember("Name", opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
                .ForMember("OrderCount", opt => opt.MapFrom(c => c.OrderCount))
                .ForMember("OrderSum", opt => opt.MapFrom(c => c.OrderSum));

                cfg.CreateMap<OrderUnitDto, OrderUnitModel>().ReverseMap()
                .ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.EndDate))
                .ForMember("RoomId", opt => opt.MapFrom(c => c.RoomId))
                .ForMember("WorkPlaceId", opt => opt.MapFrom(c => c.WorkPlaceId))
                .ForMember("WorkPlaceInRoomId", opt => opt.MapFrom(c => c.WorkPlaceInRoomId))
                .ForMember("AdditionalServiceId", opt => opt.MapFrom(c => c.AdditionalServiceId))
                .ForMember("OrderId", opt => opt.MapFrom(c => c.OrderId))
                .ForMember("OrderUnitCost", opt => opt.MapFrom(c => c.OrderUnitCost));

                cfg.CreateMap<GetAllUnitOrdersFromSpecificOrderDTO, AllUnitOrdersFromSpecificOrderModel>()
                .ForMember("StartDate", opt => opt.MapFrom(c => c.StartDate))
                .ForMember("EndDate", opt => opt.MapFrom(c => c.EndDate))
                .ForMember("Name", opt => opt.MapFrom(c => $"{c.RoomName}{c.ServiceName}"))
                .ForMember("Number", opt => opt.MapFrom(c => c.Number));
            }));
        }
    }
}
