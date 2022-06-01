using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;



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
