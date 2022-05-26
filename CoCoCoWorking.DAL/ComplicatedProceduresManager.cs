using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class ComplicatedProceduresManager
    {
        public string connectionString = @"Server=.;Database=CoCoCoworking.DB;Trusted_Connection=True;";

        public List<GetAllAdditionalServiceDTO> GetAllAdditionalService()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<GetAllAdditionalServiceDTO>
                    (StoredProcedures.GetAllAdditionalService,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }

        public List<GetAllCustomerWhithOrderWithOrderUnitDTO> GetAllCustomerWhithOrderWithOrderUnit()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<GetAllCustomerWhithOrderWithOrderUnitDTO>
                    (StoredProcedures.GetAllCustomerWhithOrderWithOrderUnit,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }
        public List<GetAllCustomerWithActiveSubscriptionDTO> GetAllCustomerWithActiveSubscription()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<GetAllCustomerWithActiveSubscriptionDTO>
                    (StoredProcedures.GetAllCustomerWithActiveSubscription,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }
        public List<GetAllRoomAndWorkPlaceBusyOrFreeDTO> GetAllRoomAndWorkPlaceBusyOrFree()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<GetAllRoomAndWorkPlaceBusyOrFreeDTO>
                    (StoredProcedures.GetAllRoomAndWorkPlaceBusyOrFree,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }
        public List<GetFinanceReportDBO> GetFinanceReport()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<GetFinanceReportDBO>
                    (StoredProcedures.GetFinanceReport,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }
    }
}
