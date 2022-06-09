using CoCoCoWorking.DAL.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.Tests.ModelControllerSources
{
    public class GetTypeOfProductForRentPriceModelTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new RentPriceDto()
                {
                    Id = 1
                },
                "MiniOffice"
            };
        }
    }
}
