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
                        ShipRegion = dataReader["ShipRegion"].ToString(),
                        ShipPostalCode = dataReader["ShipPostalCode"].ToString(),
                        Status = tempStatus
                    });
                }
                dataReader.Close();
            }
            return orders;
        }

        public void GetAllOrdersWithDetails()
        {
            //Выбраны некоторые поля, чтобы помещались при отображении в консоли
            const string sql = "SELECT t1.OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipName, ShipCountry, t2.ProductID, ProductName, t3.UnitPrice  " +
                               "FROM " +
                               "   Orders t1 " +
                               "INNER JOIN " +
                               "   [dbo].[Order Details] t2 ON t2.OrderID = t1.OrderID " +
                               "INNER JOIN " +
                               "   Products t3 ON t2.ProductID = t3.ProductID";

            OpenConnection(_conn);
            var adapter = new SqlDataAdapter(sql, _connect);
            var ds = new DataSet();
            adapter.Fill(ds);
            
            var dt = ds.Tables[0];

            
            foreach (DataColumn column in dt.Columns)
                Console.Write("\t{0}", column.ColumnName);
            Console.WriteLine();
            // перебор всех строк таблицы
            foreach (DataRow row in dt.Rows)
            {
                // получаем все ячейки строки
                var cells = row.ItemArray;
                foreach (var cell in cells)
                    Console.Write("\t{0}", cell);
                Console.WriteLine();
            }
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

        public void DeleteOrder(int orderId)
        {
            OpenConnection(_conn);
            // Сначала удаляем запись из таблицы Order Details, поскольку в ней содержится внешний ключ ссылающийся на таблицу Orders
            // После этого приступаем к удалению записи из таблицы Orders
            // OrderDate IS NULL - Статус "Новый"
            // ShippedDate IS NULL - Статус "В работе"
            var sql = $"DELETE from [dbo].[Order Details] where OrderID = @OrderID;" +
                      $"Delete from Orders where OrderID = @OrderID AND (OrderDate IS NULL OR ShippedDate IS NULL)";

            using (var command = new SqlCommand(sql, _connect))
            {
                {
                    try
                    {
                        command.Parameters.AddWithValue("@OrderID", orderId);
                        command.ExecuteNonQuery();
                    }

                    catch (SqlException ex)
                    {
                        var error = new Exception("Sorry!", ex);
                        throw error;
                    }
                }
            }
            CloseConnection();
        }

        public void UpdateOrder(int orderId, string customerId, int? employeeId, DateTime RequiredDate, int? shipVia, decimal? freight,
            string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            OpenConnection(_conn);
            var sql = 
                      $"Update Orders Set " +
                      $"CustomerId = '{customerId}'," +
                      $"EmployeeId = '{employeeId}'," +
                      $"RequiredDate = '{RequiredDate}'," +
                      $"ShipVia = '{shipVia}'," +
                      $"Freight = '{freight}'," +
                      $"ShipName = '{shipName}'," +
                      $"ShipAddress = '{shipAddress}'," +
                      $"ShipCity = '{shipCity}'," +
                      $"ShipRegion = '{shipRegion}'," +
                      $"ShipPostalCode = '{shipPostalCode}'," +
                      $"ShipCountry = '{shipCountry}'" +
                      $"WHERE OrderID = {orderId}" +
                      $"AND OrderDate IS NULL";

            using (var command = new SqlCommand(sql, _connect))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void UpdateOrderStatusToInWork(int orderId, DateTime orderDate)
        {
            OpenConnection(_conn);
            var sql = $"Update Orders Set OrderDate = '{orderDate}' WHERE OrderID = {orderId}";
            using (var command = new SqlCommand(sql, _connect))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void UpdateOrderStatusToCompleted(int orderId, DateTime shippedDate)
        {
            OpenConnection(_conn);
            var sql = $"Update Orders Set ShippedDate = '{shippedDate}' WHERE OrderID = {orderId}";
            using (var command = new SqlCommand(sql, _connect))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
    }
}

