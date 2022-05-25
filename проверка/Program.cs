
using System.Threading.Tasks;
using CoCoCoWorking.DAL;
using CoCoCoWorking.DAL.DTO;


var IU = new OrderManager();

List<OrderDTO> orderAdds = IU.OrderAdd();

foreach (var i in orderAdds)
{
    Console.WriteLine(i.ToString());
}

