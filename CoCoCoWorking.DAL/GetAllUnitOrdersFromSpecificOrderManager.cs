using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public  class GetAllUnitOrdersFromSpecificOrderManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<GetAllUnitOrdersFromSpecificOrderDTO> GetAllUnitOrdersFromSpecificOrder(int orderId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return (List<GetAllUnitOrdersFromSpecificOrderDTO>)connection.Query<GetAllUnitOrdersFromSpecificOrderDTO>(
                    StoredProcedures.GetAllUnitOrdersFromSpecificOrder,
                    param: new { OrderId = orderId },
                    commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }
    }
}
