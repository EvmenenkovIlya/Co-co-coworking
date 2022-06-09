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
                    WorkPlaceCount = 0,
                    AdditionalServiceId = null,
                    AdditionalServiceName = null,
                    AdditionalServiceCount = 0,
                    Summ = 19000.99
                },
                "Cool office"
            };

            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 2,
                    RoomId = 1,
                    RoomName = "Bad office",
                    RoomCount = 1,
                    WorkPlaceCount = 0,
                    AdditionalServiceId = null,
                    AdditionalServiceName = null,
                    AdditionalServiceCount = 0,
                    Summ = 19000.99
                },
                "Bad office"
            };

            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 3,
                    RoomId = null,
                    RoomName = null,
                    RoomCount = 0,
                    WorkPlaceCount = 0,
                    AdditionalServiceId = null,
                    AdditionalServiceName = "Notebook",
                    AdditionalServiceCount = 8,
                    Summ = 19000.99
                },
                "Notebook"
            };

            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 4,
                    RoomId = null,
                    RoomName = null,
                    RoomCount = 0,
                    WorkPlaceCount = 0,
                    AdditionalServiceId = null,
                    AdditionalServiceName = "Luggage storage",
                    AdditionalServiceCount = 4,
                    Summ = 19000.99
                },
                "Luggage storage"
            };

            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 5,
                    RoomId = null,
                    RoomName = null,
                    RoomCount = 0,
                    WorkPlaceCount = 4,
                    AdditionalServiceId = null,
                    AdditionalServiceName = null,
                    AdditionalServiceCount = 0,
                    Summ = 19000.99
                },
                "WorkPlaces"
            };

            yield return new object[]
            {
                new FinanceReportDto()
                {
                    Id = 6,
                    RoomId = null,
                    RoomName = null,
                    RoomCount = 0,
                    WorkPlaceCount = 8,
                    AdditionalServiceId = null,
                    AdditionalServiceName = null,
                    AdditionalServiceCount = 0,
                    Summ = 19000.99
                },
                "WorkPlaces"
            };
        }
    }
}
