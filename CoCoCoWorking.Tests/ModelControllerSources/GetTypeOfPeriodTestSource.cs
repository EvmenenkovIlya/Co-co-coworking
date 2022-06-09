using CoCoCoWorking.BLL;
using CoCoCoWorking.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetTypeOfPeriodTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 1,
                   RoomId = 1,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = null,
                   PeriodType = "OneWeek",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.OneWeek
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 2,
                   RoomId = 2,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = null,
                   PeriodType = "OneDay",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.OneDay
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 3,
                   RoomId = 2,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = null,
                   PeriodType = "OneMonth",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.OneMonth
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 3,
                   RoomId = null,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = 1,
                   PeriodType = "OneHour",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.OneHour
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 3,
                   RoomId = 6,
                   WorkPlaceInRoomId = 2,
                   AdditionalServiceId = null,
                   PeriodType = "EightHours",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.EightHours
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 3,
                   RoomId = 8,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = null,
                   PeriodType = "SixMonths",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.SixMonths
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 3,
                   RoomId = 9,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = null,
                   PeriodType = "EightMonths",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.EightMonths
            };

            yield return new object[]
            {
               new RentPriceDto()
               {
                   Id = 3,
                   RoomId = 10,
                   WorkPlaceInRoomId = null,
                   AdditionalServiceId = null,
                   PeriodType = "OneYear",
                   RegularPrice = 1500,
                   ResidentPrice = 1200,
                   FixedPrice = 1600,
                   IsDeleted = false,
               },
               TypeOfPeriod.OneYear
            };
        }
    }
}
