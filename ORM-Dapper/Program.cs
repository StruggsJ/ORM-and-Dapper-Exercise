using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepository(conn);


            #region Department Section (Ex1)
            //Insert a department.

            departmentRepo.InsertDepartment("Food/Beverages"); //Duplicate /w ID 7


            //Get's all departments and prints out Department's name and ID number

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion

            #region Product Section (Ex2)
            var productRepository = new DapperProductRepository(conn);
            var products = productRepository.GetAllProducts();

            /*
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("=============");
            Console.WriteLine("=============");
            */
            #endregion

            #region UpdateProduct (B1)

            /* 
            var productToUpdate = productRepository.GetProduct(940); //ID of our sample product, Gold Peak Example Sweet Tea

            productToUpdate.Name = "Gold Peak Sweet Tea"; //Removed Example in the name.
            productToUpdate.Price = 1.99; // From 3.99 to 1.99
            productToUpdate.CategoryID = 10; //Unchanged
            productToUpdate.OnSale = true; //Set onsale flag from false to true.
            productToUpdate.StockLevel = 50; //From 100 to 50;

            productRepository.UpdateProduct(productToUpdate);

            products = productRepository.GetAllProducts(); //Call method again and reassign to products to retrieved updated product.
            
            Console.WriteLine("Updated Product List:");

            
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
            */
            #endregion

            #region DeleteProduct (B2)

            productRepository.DeleteProduct(887); //Deleting our example product.
            products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion
        }
    }
}
