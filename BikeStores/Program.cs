using BikeStores.Data;
using BikeStores.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace BikeStores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext DbContext = new ApplicationDbContext();

            //1.Retrieve all categories from the production.categories table.
            var categories = DbContext.Categories;
            foreach (var item in categories)
                Console.WriteLine($" CategoryId:{item.CategoryId} CategoryName: {item.CategoryName}");

            //2.Retrieve the first product from the production.products table.
            var products = DbContext.Products.Find(1);
            Console.WriteLine($"ProductName:{products.ProductName},Id:{products.ProductId}");


            //3.Retrieve a specific product from the production.products table by ID.
            var products2 = DbContext.Products.OrderBy(e => e.ProductId).ToList();
            foreach (var item in products2)
            {
                    Console.WriteLine($"ProductName:{item.ProductName},Id:{item.ProductId}");
            }
           


            //4.Retrieve all products from the production.products table with a certain model year.
            var products3 = DbContext.Products.Where(e => e.ModelYear == 2017);
            foreach (var item in products3)
            {
                Console.WriteLine($"ProductName:{item.ProductName},Id:{item.ProductId},ModelYear:{item.ModelYear}");
            }
            


            //5.Retrieve a specific customer from the sales.customers table by ID.
            var customers = DbContext.Customers.OrderBy(e => e.CustomerId).ToList();
            foreach (var item in customers)
            {
                Console.WriteLine($"id: {item.CustomerId} name:{item.FirstName} {item.LastName}");
            }

            //6.Retrieve a list of product names and their corresponding brand names.
            var productss = DbContext.Products.Include(e => e.Brand).ToList();
            foreach (var item in productss)
            {
                Console.WriteLine($"ProductName:{item.ProductName} , BrandId:{item.BrandId}");
            }

            //7.Count the number of products in a specific category
           var products4 = DbContext.Products.Include(e => e.Category).ToList();
            foreach(var item in products4)
            {
                Console.WriteLine(item.Category.CategoryName);
            }


            //8.Calculate the total list price of all products in a specific category.
            var products5 = DbContext.Products.Sum(e => e.ListPrice);
            foreach (var item in products4)
            {
                Console.WriteLine(item.ProductName);
            }


            //9.Calculate the average list price of products.
            var products6 = DbContext.Products.ToList().Average(e => e.ListPrice);
            foreach (var item in products4)
            {
                Console.WriteLine(item.ListPrice);
            }

            //10.Retrieve orders that are completed.
            var orders = DbContext.Orders.Where(e=> e.OrderStatus == 4 );
            foreach (var item in orders)
            {
                Console.WriteLine( item.OrderStatus);
            }





        }
    }
}
