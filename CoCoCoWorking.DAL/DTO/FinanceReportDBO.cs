using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class FinanceReportDBO
    {
        public int Id { get; set; }
        public List<RoomDTO>? Rooms { get; set; } = new List<RoomDTO>();
        public List<WorkplaceDTO>? Workplaces { get; set; } = new List<WorkplaceDTO>();
        public List<AdditionalServiceDTO>? Additionalservices { get; set; } = new List<AdditionalServiceDTO>();    
        public int? Summ { get; set; }     
    }
}
