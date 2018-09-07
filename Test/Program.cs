using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List();
            Console.WriteLine("Presione Enter para continuar");
            Console.ReadKey();
        }

        static void AddCategoryAndProduct()
        {
            //Category c = new Category
            //{
            //    CategoryName = "Mariscos",
            //    Description = "Todos los mariscos"
            //};

            ////Crear el producto

            Product Chompipe = new Product
            {
                CategoryID = 10,
                ProductName = "Chompipie-30/08/2017",
                UnitPrice = 5,
                UnitsInStock = 0
            };

            var r = RepositoryFactory.CreateRepository();
            r.Create(Chompipe);

            Console.WriteLine($"Producto: {Chompipe.ProductID}");
        }

        static void RetrieveAndUpdate()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                var p = r.Retrieve<Product>(
                    s => s.ProductID == 80);
                if (p != null)
                {
                    Console.WriteLine(p.ProductName);
                    p.ProductName = p.ProductName + "***";
                    r.Update(p);
                    Console.WriteLine("Producto Modificado");
                    Console.WriteLine(p.ProductName);
                }
                else
                {
                    Console.WriteLine("Producto no existe.");
                }
            }
        }

        static void List()
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                var productos = r.Filter<Product>(p => p.CategoryID == 5);
                foreach (var product in productos)
                {
                    Console.WriteLine($"{product.ProductName}");
                }
            }
        }
    }
}
