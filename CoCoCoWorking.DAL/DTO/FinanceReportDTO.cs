using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class FinanceReportDTO
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string RoomName { get; set; }
        public int? RoomCount { get; set; }
        public int? WorkPlaceCount { get; set; }
        public int? AdditionalServiceId { get; set; }
        public string AdditionalServiceName { get; set; }
        public int? AdditionalServiceCount { get; set; }
        public double? Summ { get; set; }
    }   
}
