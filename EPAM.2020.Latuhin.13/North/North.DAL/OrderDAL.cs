using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
