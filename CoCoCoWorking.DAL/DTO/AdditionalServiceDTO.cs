using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AdditionalServiceDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Count { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return $"Id={Id} Name={Name} Count={Count} IsDeleted={IsDeleted}";
        }
    }
}
