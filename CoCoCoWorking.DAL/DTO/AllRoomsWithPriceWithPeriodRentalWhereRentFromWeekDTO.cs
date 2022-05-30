﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class AllRoomsWithPriceWithPeriodRentalWhereRentFromWeekDTO
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public List<RoomDTO>? Rooms { get; set; }
        public List<RentPriceDTO>? Rentprices { get; set; } = new List<RentPriceDTO>();
    }
}