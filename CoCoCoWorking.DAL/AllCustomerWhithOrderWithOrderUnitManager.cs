using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllCustomerWhithOrderWithOrderUnitManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<CustomersWithOrdersDto> GetAllCustomerWhithOrderWithOrderUnit()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                Dictionary<int, CustomersWithOrdersDto> result = new Dictionary<int, CustomersWithOrdersDto>();   

                     connection.Query<CustomersWithOrdersDto, OrderDto, OrderUnitDto, CustomersWithOrdersDto>
                     ("GetAllCustomerWhithOrderWithOrderUnit",
                     (customer, order, orderunit) =>
                     {

                         if (!result.ContainsKey(customer.Id))
                         {
                             result.Add(customer.Id, customer);
                         }
                         CustomersWithOrdersDto crnt = result[customer.Id];

                         if (customer!=null)
                         {
                             if (crnt.Orders != null && !crnt.Orders.Contains(order))
                             {
                                 crnt.Orders.Add(order);
                                 int index = crnt.Orders.IndexOf(order);
                                 if (orderunit!= null)
                                 {
                                    crnt.Orders[index].OrderUnits.Add(orderunit);
                                 }
                             }                                                        
                         }
                         return crnt;
                     },
                     
                     commandType: System.Data.CommandType.StoredProcedure,
                     splitOn: "Id"
                     );
                return result.Values.ToList();
            }
        }
    }
}

