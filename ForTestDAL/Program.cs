using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;

var CM = new CustomerManager();

List<CustomerDTO> customers = CM.GetAllCustomers();

foreach (var i in customers)
{
    Console.WriteLine(i.ToString());
}

//CM.AddCustomer("Niko", "Roman", "444-321-555", "NikoDarkStalker@mail.com");
CM.UpdateCustomer(2,"Roman", "Niko", "555-321-444", "RomanDarkStalker96@mail.com");

Console.WriteLine(CM.GetCustomerByID(2));