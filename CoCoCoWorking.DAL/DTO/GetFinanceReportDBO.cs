using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class GetFinanceReportDBO
    {
        public int RoomId { get; set; }
        public int WorkPlaceId { get; set; }
        public int AdditionalServiceId { get; set; }
        public int? Summ { get; set; }

        public override string ToString()
        {
            return $"RoomId={RoomId} WorkPlaceId={WorkPlaceId} AdditionalServiceId={AdditionalServiceId} Summ={Summ}";
        }
    }
}
