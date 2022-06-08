using CoCoCoWorking.BLL;
using CoCoCoWorking.BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetTypeOfProductRoomModelTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new RoomModel()
                {
                    Id = 1,
                    Type = TypeOfProduct.MiniOffice,
                    Name = "Bad room",
                    WorkPlaceNumber = 1
                },
                "MiniOffice"
            };

            yield return new object[]
            {
                new RoomModel()
                {
                    Id = 2,
                    Type = TypeOfProduct.ConferenceHall,
                    Name = "Good room",
                    WorkPlaceNumber = 1
                },
                "ConferenceHall"
            };

            yield return new object[]
            {
                new RoomModel()
                {
                    Id = 3,
                    Type = TypeOfProduct.MeetingRoom,
                    Name = "Bad room",
                    WorkPlaceNumber = 1
                },
                "MeetingRoom"
            };
        }
    }
}
