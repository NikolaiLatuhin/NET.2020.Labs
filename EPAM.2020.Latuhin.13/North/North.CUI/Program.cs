using North.DAL;
using System;

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

        }
    }
}
