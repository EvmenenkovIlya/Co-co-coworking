using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class GetAllAdditionalServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PeriodType { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal ResidentPrice { get; set; }
        public decimal FixedPrice { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Name={Name} StartDate={StartDate} EndDate={EndDate} PeriodType={PeriodType} RegularPrice={RegularPrice} ResidentPrice={ResidentPrice} FixedPrice={FixedPrice}";
        }
    }
}
