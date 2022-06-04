using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class WorkplaceDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int? Number { get; set; }
        public int? WorkplaceCount { get; set; }
    }
}
