using CoCoCoWorking.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetLastDateTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CustomersWithOrdersDto()
                {
                    Id = 1,
                    FirstName = "Ilya",
                    LastName = "Bozhkov",
                    PhoneNumber = "89347537321",
                    Email = "knsdkfjsjf.ad@mail.ru",
                    Orders = new List<OrderDto>()
                    {
                        new OrderDto()
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderCost = 999,
                            OrderStatus = "oplacheno",
                            PaidDate = "2022-06-03",
                            OrderUnits = new List<OrderUnitDto> ()
                            {
                                new OrderUnitDto ()
                                {
                                    Id = 1,
                                    StartDate = "2022-06-10",
                                    EndDate = "2022-07-20",
                                    RoomId = null,
                                    WorkPlaceId = null,
                                    WorkPlaceInRoomId = null,
                                    AdditionalServiceId = 1,
                                    OrderId = 1,
                                    OrderUnitCost = 500
                                },
                                new OrderUnitDto ()
                                {
                                    Id = 2,
                                    StartDate = "2022-07-25",
                                    EndDate = "2022-08-20",
                                    RoomId = 2,
                                    WorkPlaceId = null,
                                    WorkPlaceInRoomId = null,
                                    AdditionalServiceId = null,
                                    OrderId = 1,
                                    OrderUnitCost = 499
                                }
                            }
                        }
                    }
                },
                "20.08.2022 0:00:00"
            };

            yield return new object[]
            {
                new CustomersWithOrdersDto()
                {
                    Id = 2,
                    FirstName = "Darya",
                    LastName = "Bakanova",
                    PhoneNumber = "89347537321",
                    Email = "knsdkfjsjf.ad@mail.ru",
                    Orders = new List<OrderDto>()
                },
                "No orders"
            };

            yield return new object[]
            {
                new CustomersWithOrdersDto()
                {
                    Id = 3,
                    FirstName = "Catrin",
                    LastName = "Ivanova",
                    PhoneNumber = "89347537321",
                    Email = "knsdkfjsjf.ad@mail.ru",
                    Orders = null
                },
                "No orders"
            };

            yield return new object[]
            {
                new CustomersWithOrdersDto()
                {
                    Id = 4,
                    FirstName = "Maks",
                    LastName = "Karbainov",
                    PhoneNumber = "89347537321",
                    Email = "knsdkfjsjf.ad@mail.ru",
                    Orders = new List<OrderDto>()
                    {
                        new OrderDto()
                        {
                            Id = 2,
                            CustomerId = 4,
                            OrderCost = 999,
                            OrderStatus = "oplacheno",
                            PaidDate = "2022-06-03",
                            OrderUnits = new List<OrderUnitDto> ()
                            {
                                new OrderUnitDto ()
                                {
                                    Id = 3,
                                    StartDate = "2022-06-10",
                                    EndDate = "2022-07-04",
                                    RoomId = 1,
                                    WorkPlaceId = null,
                                    WorkPlaceInRoomId = null,
                                    AdditionalServiceId = null,
                                    OrderId = 1,
                                    OrderUnitCost = 500
                                },
                                new OrderUnitDto ()
                                {
                                    Id = 4,
                                    StartDate = "2022-07-25",
                                    EndDate = "2022-08-24",
                                    RoomId = 2,
                                    WorkPlaceId = null,
                                    WorkPlaceInRoomId = null,
                                    AdditionalServiceId = null,
                                    OrderId = 1,
                                    OrderUnitCost = 499
                                }
                            }
                        },
                        new OrderDto()
                        {
                            Id = 3,
                            CustomerId = 4,
                            OrderCost = 999,
                            OrderStatus = "oplacheno",
                            PaidDate = "2022-06-03",
                            OrderUnits = new List<OrderUnitDto> ()
                            {
                                new OrderUnitDto ()
                                {
                                    Id = 1,
                                    StartDate = "2022-05-10",
                                    EndDate = "2022-05-25",
                                    RoomId = 1,
                                    WorkPlaceId = null,
                                    WorkPlaceInRoomId = null,
                                    AdditionalServiceId = null,
                                    OrderId = 1,
                                    OrderUnitCost = 500
                                },
                                new OrderUnitDto ()
                                {
                                    Id = 1,
                                    StartDate = "2022-07-25",
                                    EndDate = "2022-08-20",
                                    RoomId = 2,
                                    WorkPlaceId = null,
                                    WorkPlaceInRoomId = null,
                                    AdditionalServiceId = null,
                                    OrderId = 1,
                                    OrderUnitCost = 499
                                }
                            }
                        }
                    }
                },
                "24.08.2022 0:00:00"
            };
        }

    }
}
