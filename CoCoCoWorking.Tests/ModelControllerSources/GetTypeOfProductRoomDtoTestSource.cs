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
    public class GetTypeOfProductRoomDtoTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new RoomDto()
                {
                    Id = 1,
                    Type = "MiniOffice",
                    Name = "Bad room",
                    WorkPlaceNumber = 15,
                    RoomCount = 1
                },
                TypeOfProduct.MiniOffice
            };

            yield return new object[]
            {
                new RoomDto()
                {
                    Id = 2,
                    Type = "MeetingRoom",
                    Name = "Good room",
                    WorkPlaceNumber = null,
                    RoomCount = 2
                },
                TypeOfProduct.MeetingRoom
            };

            yield return new object[]
            {
                new RoomDto()
                {
                    Id = 3,
                    Type = "ConferenceHall",
                    Name = "Cool room",
                    WorkPlaceNumber = null,
                    RoomCount = 3
                },
                TypeOfProduct.ConferenceHall
            };
        }
    }
}
