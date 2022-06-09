using CoCoCoWorking.BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetSumOrderUnitsTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<OrderUnitModel> ()
                {
                    new OrderUnitModel ()
                    {
                        Id = 1,
                        StartDate = "2022-05-06",
                        EndDate = "2022-05-26",
                        RoomId = 1,
                        WorkPlaceId = null,
                        WorkPlaceInRoomId = null,
                        AdditionalServiceId = null,
                        OrderId = 1,
                        OrderUnitCost = 2299.99m
                    },
                    new OrderUnitModel ()
                    {
                        Id = 2,
                        StartDate = "2022-05-06",
                        EndDate = "2022-05-26",
                        RoomId = null,
                        WorkPlaceId = null,
                        WorkPlaceInRoomId = null,
                        AdditionalServiceId = 1,
                        OrderId = 1,
                        OrderUnitCost = 1299.99m
                    },
                    new OrderUnitModel ()
                    {
                        Id = 3,
                        StartDate = "2022-05-06",
                        EndDate = "2022-05-26",
                        RoomId = null,
                        WorkPlaceId = null,
                        WorkPlaceInRoomId = null,
                        AdditionalServiceId = 6,
                        OrderId = 1,
                        OrderUnitCost = 3299.99m
                    },
                    new OrderUnitModel ()
                    {
                        Id = 4,
                        StartDate = "2022-05-06",
                        EndDate = "2022-05-26",
                        RoomId = null,
                        WorkPlaceId = 4,
                        WorkPlaceInRoomId = 2,
                        AdditionalServiceId = null,
                        OrderId = 1,
                        OrderUnitCost = 2699.99m
                    }
                },
                9599.96m
            };

           yield return new object[]
           {
                new List<OrderUnitModel>()
                {
                    new OrderUnitModel ()
                    {
                        Id = 5,
                        StartDate = "2022-05-06",
                        EndDate = "2022-05-26",
                        RoomId = 1,
                        WorkPlaceId = null,
                        WorkPlaceInRoomId = null,
                        AdditionalServiceId = null,
                        OrderId = 1,
                        OrderUnitCost = 2299.99m
                    },
                    new OrderUnitModel ()
                    {
                        Id = 6,
                        StartDate = "2022-05-06",
                        EndDate = "2022-05-26",
                        RoomId = null,
                        WorkPlaceId = null,
                        WorkPlaceInRoomId = null,
                        AdditionalServiceId = 1,
                        OrderId = 1,
                        OrderUnitCost = 3000m
                    },
                    
                },
                5299.99m
            };
    }
    }
   
}
