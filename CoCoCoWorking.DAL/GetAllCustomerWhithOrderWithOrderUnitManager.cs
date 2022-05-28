using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class GetAllCustomerWhithOrderWithOrderUnitManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<CustomerDTO> GetAllCustomerWhithOrderWithOrderUnit()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                Dictionary<int, CustomerDTO> result = new Dictionary<int, CustomerDTO>();   

                     connection.Query<CustomerDTO, OrderDTO, OrderUnitDTO, CustomerDTO>
                     ("GetAllCustomerWhithOrderWithOrderUnit",
                     (customer, order, orderunit) =>
                     {
                         
                        if(!result.ContainsKey(customer.Id))
                         {
                             result.Add(customer.Id, customer);
                         }
                         CustomerDTO crnt = result[customer.Id];

                         if(customer!=null)
                         {
                         crnt.Orders.Add(order);
                         crnt.OrderUnits.Add(orderunit);
                         }
                         return crnt;
                     },
                     StoredProcedures.GetAllCustomerWhithOrderWithOrderUnit,
                     commandType: System.Data.CommandType.StoredProcedure,
                     splitOn: "id"
                     );
                return result.Values.ToList();
            }
        }
    }
}

