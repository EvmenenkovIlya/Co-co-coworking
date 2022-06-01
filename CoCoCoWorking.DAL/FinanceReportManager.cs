﻿using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;


namespace CoCoCoWorking.DAL
{
    public class FinanceReportManager
    {
        public string connectionString = ServerOptions.ConnectionOption;

        public List<FinanceReportDTO> GetFinanceReport(string startDate, string EndDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<FinanceReportDTO>
                    (StoredProcedures.GetFinanceReport,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }

        public List<FinanceReportByCustomerDTO> GetFinanceReportByCustomer(string startDate, string EndDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<FinanceReportByCustomerDTO>
                    (StoredProcedures.GetFinanceReportByCustomer,
                       commandType: System.Data.CommandType.StoredProcedure)
                       .ToList();
            }
        }
    }
}
