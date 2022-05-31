﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCoCoWorking.DAL.DTO
{
    public class FinanceReportByCustomerDTO
    {
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }	
		public string PhoneNumber { get; set; }
		public string? Email { get; set; }
		public int OrderCount { get; set; }
		public double OrderSum { get; set; }
	}
}