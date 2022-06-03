﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.BLL.Models
{
    public class RentPriceModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? WorkPlaceInRoomId { get; set; }
        public int? AdditionalServiceId { get; set; }
        public Enum Type { get; set; }
        public string Name { get; set; }
        public Enum PeriodType { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? ResidentPrice { get; set; }
        public decimal? FixedPrice { get; set; }
    }
}
