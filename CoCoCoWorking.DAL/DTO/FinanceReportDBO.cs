﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class FinanceReportDBO
    {
        public int RoomId { get; set; }
        public int? RoomCount { get; set; }
        public int WorkplaceId {get;set;}
        public int? WorkPlaceCount { get; set; }
        public int AdditionalServiceId { get; set; }
        public int AdditionalServiceCount { get; set; }
        public int? Summ { get; set; }

        
    }
}