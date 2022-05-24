using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;

var CM = new CustomerManager();

List<CustomerDTO> customers = CM.GetAllCustomers();

foreach (var i in customers)
{
    Console.WriteLine(i.ToString());
}


Console.WriteLine(CM.GetCustomerByOrderID(1));