using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;
using CoCoCoWorking.BLL;
using CoCoCoWorking.BLL.Models;
using AutoMapper;
//var CM = new CustomerManager();

//List<CustomerDTO> customers = CM.GetAllCustomers();

//foreach (var i in customers)
//{
//    Console.WriteLine(i.ToString());
//}

var CM = new AllCustomerWhithOrderWithOrderUnitManager();
var O = CM.GetAllCustomerWhithOrderWithOrderUnit();

    Console.WriteLine(O);


//var CM = new FinanceReportManager();
//var O = CM.GetFinanceReport();
//foreach (var i in O)
//{
//    Console.WriteLine(i);
//}

////CM.AddCustomer("Niko", "Roman", "444-321-555", "NikoDarkStalker@mail.com");
//CM.UpdateCustomer(2,"Roman", "Niko", "555-321-444", "RomanDarkStalker96@mail.com");

//Console.WriteLine(CM.GetCustomerByID(2));

//var RM = new RoomManager();


//RM.AddRoom("Ромашка", 5);
//RM.AddRoom("Одуванчик", 10);
//List<RoomDTO> rooms = RM.GetAllRooms();
//foreach (var i in rooms)
//{
//    Console.WriteLine(i.ToString());
//}
//RM.UpdateRoom(2, "Лилия", 15);
//Console.WriteLine(RM.GetRoomByID(2));
//Console.WriteLine("Test");



//var R = new RoomManager();
//List<RoomDTO> rr = R.GetAllRooms();

//foreach (var i in rr)
//{
//    Console.WriteLine(i);
//}



OrderUnitDTO OrderUnitDTO = new OrderUnitDTO()
{
    Id = 1,
    StartDate = "01.01.2000",
    EndDate = "01.03.2000",
    RoomId = 12,
    WorkPlaceId = 10,
    WorkPlaceInRoomId = 100,
    AdditionalServiceId = 3,
    OrderId = 13,
    OrderUnitCost = 300
};


MapperConfigStorage storage = new MapperConfigStorage();
var config = MapperConfigStorage.GetInstance();

Mapper mapper = new Mapper(config.ConfigurationProvider);

OrderUnitModel OrderUnitModel = mapper.Map<OrderUnitModel>(OrderUnitDTO);

Console.WriteLine();