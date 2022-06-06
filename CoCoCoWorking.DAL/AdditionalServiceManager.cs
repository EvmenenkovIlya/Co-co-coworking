using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class AdditionalServiceManager
    {
        public string connectionString = ServerOptions.ConnectionOption;
        public List<AdditionalServiceDto> GetAllAdditionalServices()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<AdditionalServiceDto>(
                    StoredProcedures.AdditionalService_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public AdditionalServiceDto GetAdditionalServiceByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle(
                    StoredProcedures.AdditionalService_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void  AddAdditionalService(AdditionalServiceDto additionalService)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                    connection.QuerySingleOrDefault(
                    StoredProcedures.AdditionalService_Add,
                    param: new
                    {
                        name = additionalService.Name,
                        count = additionalService.Count,    
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void UpdateAdditionalService(AdditionalServiceDto additionalService)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AdditionalServiceDto>(
                StoredProcedures.AdditionalService_Update,
                param: new
                {
                    id = additionalService.Id,
                    name = additionalService.Name,
                    count = additionalService.Count,
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteAdditionalService(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<AdditionalServiceDto>(
                StoredProcedures.AdditionalService_SoftDelete,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public List<AllAdditionalServiceDto> AllAdditionalService()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Dictionary<int, AllAdditionalServiceDto> result = new Dictionary<int, AllAdditionalServiceDto>();

                connection.Query<AllAdditionalServiceDto, OrderUnitDto, RentPriceDto, AllAdditionalServiceDto>
                (StoredProcedures.GetAllAdditionalService,
                (additionalservice, orderunit, rentprice) =>
                {

                    if (!result.ContainsKey(additionalservice.Id))
                    {
                        result.Add(additionalservice.Id, additionalservice);
                    }
                    AllAdditionalServiceDto crnt = result[additionalservice.Id];

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
