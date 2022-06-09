using CoCoCoWorking.BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetCustomerWithTheMatchedNumberIsReturnedTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                "45",
                new List<CustomerModel>
                {
                    new CustomerModel()
                    {
                        Id = 1,
                        FirstName = "Ilya",
                        LastName = "Bozhkov",
                        PhoneNumber = "89653848245",
                        Email = "ilia.il.27@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Darya",
                        LastName = "Bakanova",
                        PhoneNumber = "89648347184",
                        Email = "dabaowk.sfko@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Katrin",
                        LastName = "Ivanova",
                        PhoneNumber = "89874975824",
                        Email = "setfsergsg@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    }
                },
                new List<CustomerModel>
                {
                    new CustomerModel()
                    {
                        Id = 1,
                        FirstName = "Ilya",
                        LastName = "Bozhkov",
                        PhoneNumber = "89653848245",
                        Email = "ilia.il.27@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    }
                }
            };

            yield return new object[]
            {
                "3478",
                new List<CustomerModel>
                {
                    new CustomerModel()
                    {
                        Id = 1,
                        FirstName = "Ilya",
                        LastName = "Bozhkov",
                        PhoneNumber = "89653478245",
                        Email = "ilia.il.27@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Darya",
                        LastName = "Bakanova",
                        PhoneNumber = "89648343478",
                        Email = "dabaowk.sfko@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Katrin",
                        LastName = "Ivanova",
                        PhoneNumber = "89347875824",
                        Email = "setfsergsg@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    }
                },
                new List<CustomerModel>
                {
                    new CustomerModel()
                    {
                        Id = 1,
                        FirstName = "Ilya",
                        LastName = "Bozhkov",
                        PhoneNumber = "89653478245",
                        Email = "ilia.il.27@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Darya",
                        LastName = "Bakanova",
                        PhoneNumber = "89648343478",
                        Email = "dabaowk.sfko@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Katrin",
                        LastName = "Ivanova",
                        PhoneNumber = "89347875824",
                        Email = "setfsergsg@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    }
                }
            };

            yield return new object[]
            {
                "89648343478",
                new List<CustomerModel>
                {
                    new CustomerModel()
                    {
                        Id = 1,
                        FirstName = "Ilya",
                        LastName = "Bozhkov",
                        PhoneNumber = "89653478245",
                        Email = "ilia.il.27@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Darya",
                        LastName = "Bakanova",
                        PhoneNumber = "89648343478",
                        Email = "dabaowk.sfko@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    },
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Katrin",
                        LastName = "Ivanova",
                        PhoneNumber = "89347875824",
                        Email = "setfsergsg@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    }
                },
                new List<CustomerModel>
                {
                    new CustomerModel()
                    {
                        Id = 2,
                        FirstName = "Darya",
                        LastName = "Bakanova",
                        PhoneNumber = "89648343478",
                        Email = "dabaowk.sfko@mail.ru",
                        Regular = false,
                        Subscribe = false,
                        EndDate = null
                    }
                }
            };
        }
    }
}
