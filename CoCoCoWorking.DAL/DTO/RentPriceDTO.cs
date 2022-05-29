﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class RentPriceDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int WorkPlaceInRoomId { get; set; }
        public int AdditionalServiceId { get; set; }
        public string PeriodType { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal ResidentPrice { get; set; }
        public decimal FixedPrice { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return $"Id={Id} RoomId={RoomId} WorkPlaceInRoomId={WorkPlaceInRoomId} AdditionalServiceId={AdditionalServiceId} PeriodType={PeriodType}" +
                   $"RegularPrice={RegularPrice} ResidentPrice={ResidentPrice} FixedPrice={FixedPrice} IsDeleted={IsDeleted} ";
        }
    }
}