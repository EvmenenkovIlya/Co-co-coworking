using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class AllAdditionalServiceManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<AllAdditionalServiceDTO> AllAdditionalService()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, AllAdditionalServiceDTO> result = new Dictionary<int, AllAdditionalServiceDTO>();

                connection.Query<AllAdditionalServiceDTO, OrderUnitDTO, RentPriceDTO, AllAdditionalServiceDTO>
                ("GetAllAdditionalService",
                (additionalservice, orderunit, rentprice) =>
                {

                    if (!result.ContainsKey(additionalservice.Id))
                    {
                        result.Add(additionalservice.Id, additionalservice);
                    }
                    AllAdditionalServiceDTO crnt = result[additionalservice.Id];

                    if (additionalservice != null)
                    {
                        crnt.Orderunits.Add(orderunit);
                        crnt.Rentprices.Add(rentprice);
                    }


                    return crnt;
                },

                commandType: System.Data.CommandType.StoredProcedure,
                splitOn: "Id, StartDate, PeriodType "
                );
                return result.Values.ToList();
            }
        }
    }
}
