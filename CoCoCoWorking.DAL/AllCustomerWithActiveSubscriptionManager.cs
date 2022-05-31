using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllCustomerWithActiveSubscriptionManager
    {
        public string connectionString = ServerOptions.ConnectionOption;
      
            public List<CustomersWithOrdersDTO> GetAllCustomerWithActiveSubscriptiont()
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    Dictionary<int, CustomersWithOrdersDTO> result = new Dictionary<int, CustomersWithOrdersDTO>();

                    connection.Query<CustomersWithOrdersDTO, OrderDTO, OrderUnitDTO, CustomersWithOrdersDTO>
                    ("GetAllCustomerWithActiveSubscription",
                    (customer, order, orderunit) =>
                    {

                        if (!result.ContainsKey(customer.Id))
                        {
                            result.Add(customer.Id, customer);
                        }
                        CustomersWithOrdersDTO crnt = result[customer.Id];

                        if (customer != null)
                        {
                            if (!crnt.Orders.Contains(order))
                            {
                                crnt.Orders.Add(order);
                            }
                            int index = crnt.Orders.IndexOf(order);
                            crnt.Orders[index].Orderunits.Add(orderunit);

                        }
                        return crnt;
                    },

                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id,Id,Id, AdditionalServiceId"
                    );
                    return result.Values.ToList();
                }
            }
    }
}
