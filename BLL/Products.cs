using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    //Toda la lógica de negocio referente a los productos.
    public class Products
    {
        public Product Create(Product newProduct)
        {
            Product Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Buscar si el nombre del producto existe
                Product res =
                    r.Retrieve<Product>(
                        p => p.ProductName == newProduct.ProductName);
                if (res == null)
                {
                    //No existe, entonces podemos crear.
                    Result = r.Create(newProduct);
                }
                else
                {
                    /*Podríamos aquí lanzar una excepción 
                    para notificar que el producto ya existe.*/


                }
            }


            return Result;
        }
        public Product RetriveById(int ID)
        {
            Product Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Product>(p => p.ProductID == ID);
            }
            return Result;

        }
        public bool Update(Product productToUpdate)
        {
            bool Result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del producto no exista
                Product Temp = r.Retrieve<Product>(p => p.ProductName == productToUpdate.ProductName && p.ProductID != productToUpdate.ProductID);
                if (Temp == null)
                {
                    //No existe
                    Result = r.Update(productToUpdate);
                }
                else
                {
                    /* Podemos implementar alguna lógica
                       Para indicar que no se puede modificar.*/
                }
            }
            return Result;
        } 

        public bool Delete(int ID)
        {
            bool Result = false;
            var Product = RetriveById(ID);
            if (Product !=null)
            {
                if (Product.UnitsInStock == 0)
                {
                    //Eliminar el producto
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        Result = r.Delete(Product);
                    }
                }
                else
                {
                    //Indicamos que no se puede eliminar
                }
            }
            else
            {
                //Indicar que el producto no existe
            }
            
            return Result;
        }
        public List<Product> FilterByCategoryID(int categoryID)
        {
            List<Product> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Product>(p => p.CategoryID == categoryID);

            }
            return Result;
        }
    }
    
}
