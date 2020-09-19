using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using North.DAL.Models;

namespace North.DAL
{
    public class OrderDAL
    {
        private SqlConnection _connect = null;

        private string _conn =
            @"Data Source=DESKTOP-UNI17SV\SQLEXPRESS01;Initial Catalog=Northwind;Integrated Security=True";

        public void OpenConnection(string connectionString)
        {
            _connect = new SqlConnection(connectionString);
            _connect.Open();
        }

        public void CloseConnection()
        {
            if (_connect.State != ConnectionState.Closed)
            {
                _connect.Close();
            }
        }

        public List<Order> GetAllOrders()
        {
            OpenConnection(_conn);
            // Здесь будут храниться записи.
            var orders = new List<Order>();
            // Подготовить объект команды,
            const string sql = "Select * From Orders";
            using (var command = new SqlCommand(sql, _connect))
            {
                command.CommandType = CommandType.Text;
                var dataReader =
                    command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    var tempStatus = Order.StatusOrder.New; 

                    if (dataReader["OrderDate"] == DBNull.Value)
                    {
                        tempStatus = Order.StatusOrder.New;
                    }
                    else if (dataReader["ShippedDate"] == DBNull.Value)
                    {
                        tempStatus = Order.StatusOrder.InWork;
                    }
                    else if (dataReader["ShippedDate"] != DBNull.Value)
                    {
                        tempStatus = Order.StatusOrder.Completed;
                    }

                    orders.Add(new Order
                    {
                        OrderId = (int)dataReader["OrderId"],
                        CustomerId = (string)dataReader["CustomerId"],
                        EmployeeId = (int?)dataReader["EmployeeId"],
                        OrderDate = (DateTime?)dataReader["OrderDate"],
                        RequiredDate = (DateTime?)dataReader["RequiredDate"],
                        ShippedDate = dataReader["ShippedDate"] as DateTime?,
                        ShipVia = (int?)dataReader["ShipVia"],
                        Freight = (decimal)dataReader["Freight"],
                        ShipName = (string)dataReader["ShipName"],
                        ShipAddress = (string)dataReader["ShipAddress"],
                        ShipCity = (string)dataReader["ShipCity"],
                        ShipRegion = (string)dataReader["ShipRegion"].ToString(),
                        ShipPostalCode = (string)dataReader["ShipPostalCode"].ToString(),
                        Status = tempStatus
                    });
                }
                dataReader.Close();
            }
            return orders;
        }

        public void InsertOrder(Order order)
        {
            OpenConnection(_conn);
            // Обратите внимание на "заполнители" в запросе SQL.
            const string sql = "Insert Into Orders" +
                               "(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, " +
                               "ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) Values" +
                               "(@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, " +
                               "@ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)";
            // Эта команда будет иметь внутренние параметры.
            using (var command = new SqlCommand(sql, _connect))
            {
                // Заполнить коллекцию параметров.
                var parameter = new SqlParameter
                {
                    ParameterName = "@CustomerID",
                    Value = order.CustomerId,
                    SqlDbType = SqlDbType.NChar,
                    Size = 5
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@EmployeeID",
                    Value = order.EmployeeId,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@OrderDate",
                    Value = order.OrderDate,
                    SqlDbType = SqlDbType.DateTime
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@RequiredDate",
                    Value = order.RequiredDate,
                    SqlDbType = SqlDbType.DateTime
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShippedDate",
                    Value = order.ShippedDate,
                    SqlDbType = SqlDbType.DateTime
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipVia",
                    Value = order.ShipVia,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Freight",
                    Value = order.Freight,
                    SqlDbType = SqlDbType.Money
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipName",
                    Value = order.ShipName,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 40
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipAddress",
                    Value = order.ShipAddress,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 60
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipCity",
                    Value = order.ShipCity,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipRegion",
                    Value = order.ShipRegion,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipPostalCode",
                    Value = order.ShipPostalCode,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@ShipCountry",
                    Value = order.ShipCountry,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 15
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
