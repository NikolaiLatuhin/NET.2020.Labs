using North.DAL;
using System;
using North.DAL.Models;

namespace North.CUI
{
    class Program
    {
        static void Main()
        {
            var dal = new OrderDAL();
            var list = dal.GetAllOrders();
            Console.WriteLine("All Orders");
            foreach (var itm in list)
            {
                Console.WriteLine($" {itm.OrderId} \t {itm.CustomerId} \t{itm.EmployeeId} \t{itm.ShipName} \t{itm.ShipAddress} \t{itm.Status}");
            }

            dal.InsertOrder(new Order
            {
                CustomerId = "TOMSP", EmployeeId = 3, OrderDate = DateTime.Now, RequiredDate = DateTime.Now, ShippedDate = DateTime.Now,
                ShipVia = 2, Freight = (decimal?) 1.4300, ShipName = "Toms Spezialitäten", ShipAddress = "Luisenstr. 48", ShipCity = "Münster",
                ShipRegion = string.Empty, ShipPostalCode = "44087", ShipCountry = "Germany", Status = Order.StatusOrder.Completed
            } );
            Console.WriteLine("Успешно добавлена запись");

            dal.DeleteOrder(11019);
            Console.WriteLine("Запись удалена");

            dal.GetAllOrdersWithDetails();

            dal.UpdateOrder(10285, "WILMK", 1, DateTime.Now, 1, (decimal)1000, "Test Ship",
                "Russia, Samara Region, Samara", "Samara", "Samara Region", "445445", "Russia" );
            Console.WriteLine("Успешно внесены изменения в запись");
        }
    }
}
