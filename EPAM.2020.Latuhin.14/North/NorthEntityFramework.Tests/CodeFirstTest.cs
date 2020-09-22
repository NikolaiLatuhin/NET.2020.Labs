using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthEntityFramework.CodeFirst;

namespace NorthEntityFramework.Tests
{
    [TestClass]
    public class CodeFirstTest
    {
		[TestMethod]
        public void ShouldReturn_OrderDetails_WhenInputWhereParameter()
        {
            using (var db = new NorthwindContext())
            {
                // categoryId = 1 (Beverages)
                // categoryId = 2 (Condiments)
                // categoryId = 3 (Confections)
                var result = from order in db.Orders
                    join orderDetail in db.OrderDetails on order.OrderId equals orderDetail.OrderId
                    join product in db.Products on orderDetail.ProductId equals product.ProductId
                    join category in db.Categories on product.CategoryId equals category.CategoryId
                    join customer in db.Customers on order.CustomerId equals customer.CustomerId
                    where category.CategoryId == 2
                    select new
                    {
                        customerCompanyName = customer.CompanyName,
                        customerContractName = customer.ContactName,
                        Category = category.CategoryName,
                        CategoryDescription = category.Description,
                        productName = product.ProductName
                    };

                foreach (var res in result)
                {
                    Console.WriteLine($"{res.customerCompanyName} {res.customerContractName} " +
                                      $"{res.Category} {res.CategoryDescription} {res.productName} {Environment.NewLine}");
                }
            }
        }
	}
}
