﻿using CoCoCoWorking.DAL.DTO;
using Dapper;
using System.Data.SqlClient;

namespace CoCoCoWorking.DAL
{
    public class OrderUnitManager
    {
        public string connectionString = @"Server=.;Database=CoCoCoworking.DB;Trusted_Connection=True;";
        public List<OrderUnitDTO> GetAllOrderUnit()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<OrderUnitDTO>(
                    StoredProcedures.OrderUnit_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
        public OrderUnitDTO GetOrderUnitByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderUnitDTO>(
                    StoredProcedures.OrderUnit_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
