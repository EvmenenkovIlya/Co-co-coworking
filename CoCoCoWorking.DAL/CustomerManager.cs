using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class CustomerManager
    {
        public string connectionString = ServerOptions.ConnectionOption ;
        public List<CustomersWithOrdersDto> GetAllCustomers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<CustomersWithOrdersDto>(
                    StoredProcedures.Customer_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public CustomersWithOrdersDto GetCustomerByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<CustomersWithOrdersDto>(
                    StoredProcedures.Customer_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void AddCustomer(CustomersWithOrdersDto customer)
        { 
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingle(
                    StoredProcedures.Customer_Add,
                    param: new {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void UpdateCustomer(CustomersWithOrdersDto customer)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.QuerySingleOrDefault(
                    StoredProcedures.Customer_Update,
                    param: new
                    {
                        id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public List<CustomersWithOrdersDto> GetAllCustomerWhithOrderWithOrderUnit()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, CustomersWithOrdersDto> result = new Dictionary<int, CustomersWithOrdersDto>();

                connection.Query<CustomersWithOrdersDto, OrderDto, OrderUnitDto, CustomersWithOrdersDto>
                (StoredProcedures.GetAllCustomerWhithOrderWithOrderUnit,
                (customer, order, orderunit) =>
                {
                    if (!result.ContainsKey(customer.Id))
                    {
                        result.Add(customer.Id, customer);
                    }
                    CustomersWithOrdersDto crnt = result[customer.Id];
                    if (customer != null)
                    {
                        if (crnt.Orders != null && !crnt.Orders.Contains(order))
                        {
                            crnt.Orders.Add(order);
                            int index = crnt.Orders.IndexOf(order);
                            if (orderunit != null)
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