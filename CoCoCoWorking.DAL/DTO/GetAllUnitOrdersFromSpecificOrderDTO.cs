using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class GetAllUnitOrdersFromSpecificOrderDTO
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string RoomName { get; set; }
        public int? Number { get; set; }
        public string ServiceName { get; set; }

        public GetAllUnitOrdersFromSpecificOrderDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is GetAllUnitOrdersFromSpecificOrderDTO))
            {
                flag = false;
            }
            GetAllUnitOrdersFromSpecificOrderDTO gaouDto = (GetAllUnitOrdersFromSpecificOrderDTO)obj;
            if (gaouDto.Id != this.Id ||
                gaouDto.StartDate != this.StartDate ||
                gaouDto.EndDate != this.EndDate ||
                gaouDto.RoomName != this.RoomName ||
                gaouDto.Number != this.Number ||
                gaouDto.ServiceName != this.ServiceName)
            {
                flag = false;
            }
            return flag;
        }
    }
}
