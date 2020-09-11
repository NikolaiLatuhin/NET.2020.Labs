// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SampleSupport;
using Task;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {
        private readonly DataSource dataSource = new DataSource();

        private bool ValidateZipCode(string val)
        {
            long number;
            return long.TryParse(val, out number);
        }

        private bool ValidatePhone(string phone)
        {
            var pattern = @"^(\([0-9]\))+?";
            return Regex.IsMatch(phone, pattern);
        }

        private List<GroupPriceEntity> SortProductsByPrice()
        {
            var sortedProducts = new List<GroupPriceEntity>();

            foreach (var prod in dataSource.Products)
                if (prod.UnitPrice <= 20M)
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 0});
                else if ((prod.UnitPrice > 20M) && (prod.UnitPrice <= 50M))
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 1});
                else
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 2});

            return sortedProducts;
        }


        [Category("Homework LINQ")]
        [Title("Example")]
        [Description("Описание задачи на русском языке")
        ]
        public void LinqForExample()
        {
            var customers = dataSource
                .Customers
                .Select(c => c);

            //Он умеет выполнять запросы самостоятельно. Так же умеет делать foreach по коллекции. 
            //Проверьте это все запустив приложение и сделав запуск запроса
            ObjectDumper.Write(customers);
        }

        [Category("Homework LINQ")]
        [Title("Task 1")]
        [Description("Выдайть список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X.")
        ]
        public void Linq1()
        {

            var x = 1000;
            //var x = 10000;

            var customersWithTotalGreatX = dataSource
                .Customers
                .Where(c => c
                    .Orders
                    .Select(o => o.Total)
                    .Sum() > x)
                .Select(c => new
                {
                    CustomerId = c.CustomerID,
                    TotalSum = c
                        .Orders
                        .Select(o => o.Total)
                        .Sum()
                });

            ObjectDumper.Write(customersWithTotalGreatX);
        }

        [Category("Homework LINQ")]
        [Title("Task 3")]
        [Description("Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X")
        ]
        public void Linq3()
        {
            decimal valueX = 1500;

            var customer = dataSource
                .Customers
                .SelectMany(o => o.Orders)
                .Where(t => t.Total > valueX);

            ObjectDumper.Write(customer);
        }

        [Category("Homework LINQ")]
        [Title("Task 6")]
        [Description("Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора " +
                     "(для простоты считаем, что это равнозначно «нет круглых скобочек в начале»).")
        ]
        public void Linq6()
        {
            var customersWithParameters = dataSource
                .Customers
                .Where(
                    c => c.PostalCode != null && !ValidateZipCode(c.PostalCode)
                         || string.IsNullOrWhiteSpace(c.Region)
                         || !ValidatePhone(c.Phone));

            ObjectDumper.Write(customersWithParameters);
        }

        [Category("Homework LINQ")]
        [Title("Task 4")]
        [Description("Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами " +
            "(принять за таковые месяц и год самого первого заказа")
        ]
        public void Linq4()
        {
            var customersFirstOrder = dataSource
                .Customers
                .Where(c => c.Orders.Any())
                .Select(c => new
                {
                    CustomerId = c.CustomerID,
                    StartDate = c.Orders
                    .OrderBy(o => o.OrderDate)
                    .Select(o => o.OrderDate)
                    .First()
                });

            ObjectDumper.Write(customersFirstOrder);
        }

        [Category("Homework LINQ")]
        [Title("Task 8")]
        [Description("Сгруппируйте товары по группам «дешевые», «средняя цена», «дорогие». Границы каждой группы задайте сами")
        ]
        public void Linq8()
        {
            var cheapPrice = 15;
            var averagePrice = 47;

            var productGroups = dataSource
                .Products
                .GroupBy(p => 
                    (p.UnitPrice < cheapPrice ? "Дешевые" : 
                     p.UnitPrice < averagePrice ? "Средняя цена" : "Дорогие"));


            foreach (var group in productGroups)
            {
                ObjectDumper.Write(group.Key);
                foreach (var product in group)
                {
                    ObjectDumper.Write($"Product {product.ProductName} Price {product.UnitPrice}.");
                }
            }
        }

        [Category("Homework LINQ")]
        [Title("Task 2")]
        [Description("Для каждого клиента составьте список поставщиков, находящихся в той же стране и том же городе.")
        ]
        public void Linq2()
        {
            var customerAndSupplierInSameCountry = dataSource
                .Customers
                .GroupJoin(dataSource
                        .Suppliers,
                    c => new { c.City, c.Country },
                    s => new { s.City, s.Country },
                    (c, s) => new { Customer = c, Suppliers = s });

            ObjectDumper.Write("Groups:\n");
            foreach (var cs in customerAndSupplierInSameCountry)
            {
                ObjectDumper.Write($"Customer {cs.Customer.CompanyName}");
                ObjectDumper.Write("Supplier from same country and city:");
                foreach (var sp in cs.Suppliers)
                {
                    ObjectDumper.Write($"{sp.SupplierName}; Country {sp.Country}; City {sp.City}");
                }
            }
        }

        [Category("Homework LINQ")]
        [Title("Task 7")]
        [Description("Сгруппируйте все продукты по категориям, внутри – по наличию на складе, внутри последней группы отсортируйте по стоимости")
        ]
        public void Linq7()
        {
            var productsWithGroupBy = dataSource
                .Products
                .GroupBy(pr => pr.Category)
                .Select(c => new
                {
                    Category = c.Key,

                    ProductsInWarehouse = c
                        .GroupBy(x => x.UnitsInStock > 0)
                        .Select(p => new
                        {
                            IsWarehouseProducts = p.Key,

                            Products = p.OrderBy(pr => pr.UnitPrice)
                        })
                });

            foreach (var p in productsWithGroupBy)
            {
                ObjectDumper.Write($"Product category: {p.Category}");

                foreach (var pr in p.ProductsInWarehouse)
                {
                    ObjectDumper.Write($"In warehouse products: {pr.IsWarehouseProducts}");

                    foreach (var product in pr.Products)
                    {
                        ObjectDumper.Write($"Name: {product.ProductName} Price {product.UnitPrice}.");
                    }
                }
            }
        }

        [Category("Homework LINQ")]
        [Title("Task 5")]
        [Description("Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу, " +
            "оборотам клиента (от максимального к минимальному) и имени клиента")
        ]
        public void Linq5()
        {
            var customersFirstOrderWithSort = dataSource
                .Customers
                .Where(c => c.Orders.Any())
                .Select(c => new
                {
                    CustomerId = c.CustomerID,

                    StartDate = c
                        .Orders
                        .OrderBy(o => o.OrderDate)
                        .Select(o => o.OrderDate)
                        .First(),

                    TotalSum = c
                        .Orders
                        .Sum(o => o.Total)

                })
                .OrderByDescending(c => c.StartDate.Year)
                .ThenByDescending(c => c.StartDate.Month)
                .ThenByDescending(c => c.TotalSum)
                .ThenByDescending(c => c.CustomerId);

            ObjectDumper.Write(customersFirstOrderWithSort);
        }

    }
}