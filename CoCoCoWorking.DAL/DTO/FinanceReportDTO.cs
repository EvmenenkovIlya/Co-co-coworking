using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class FinanceReportDto
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

        public FinanceReportDto()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is FinanceReportDto))
            {
                flag = false;
            }
            FinanceReportDto frDto = (FinanceReportDto)obj;
            if (frDto.Id != this.Id ||
                frDto.RoomId != this.RoomId ||
                frDto.RoomName != this.RoomName ||
                frDto.RoomCount != this.RoomCount ||
                frDto.WorkPlaceCount != this.WorkPlaceCount ||
                frDto.AdditionalServiceId != this.AdditionalServiceId ||
                frDto.AdditionalServiceName!= this.AdditionalServiceName||
                frDto.AdditionalServiceCount!=this.AdditionalServiceCount||
                frDto.Summ!=this.Summ)
            {
                flag = false;
            }
            return flag;
        }
    }   
}
