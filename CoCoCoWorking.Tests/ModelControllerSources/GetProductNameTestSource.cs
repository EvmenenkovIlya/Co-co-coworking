using CoCoCoWorking.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetProductNameTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 1,
                    RoomId = 1,
                    RoomName = "Cool office",
                    RoomCount = 1,
                    WorkPlaceCount = null,
                    AdditionalServiceId = null,
                    AdditionalServiceName = null,
                    AdditionalServiceCount = null,
                    Summ = 19000.99
                },
                "Cool office"
            };

            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 1,
                    RoomId = 1,
                    RoomName = null,
                    RoomCount = 1,
                    WorkPlaceCount = null,
                    AdditionalServiceId = null,
                    AdditionalServiceName = "Notebook",
                    AdditionalServiceCount = null,
                    Summ = 19000.99
                },
                "Notebook"
            };

            yield return new object[]
           {
                new FinanceReportDto()
                {
                    Id = 1,
                    RoomId = 1,
                    RoomName = null,
                    RoomCount = 1,
                    WorkPlaceCount = null,
                    AdditionalServiceId = null,
                    AdditionalServiceName = null,
                    AdditionalServiceCount = null,
                    Summ = 19000.99
                },
                "WorkPlaces"
           };
        }
    }
}
