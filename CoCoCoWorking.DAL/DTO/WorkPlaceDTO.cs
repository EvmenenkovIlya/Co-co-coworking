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

        public override string ToString()
        {
            return $"Id={Id} RommId={RoomId} Number={Number}";
        }
    }
}
