﻿using System;
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
    }
}