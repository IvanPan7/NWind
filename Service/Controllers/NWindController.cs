using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Entities;


namespace Service.Controllers
{
    public class NWindController : ApiController
    {
        [HttpPost]
        public Product CreateProduct(Product newProduct)
        {
            var BL = new Products();
            var NewProduct = BL.Create(newProduct);
            return NewProduct;
        }

        [HttpGet]
        public bool DeleteProduct(int ID)
        {
            var BL = new Products();
            var Result = BL.Delete(ID);
            return Result;
        }

        [HttpGet]
        public List<Product> FilterProductsByCategoryID(int ID)
        {
            var BL = new Products();
            var Result = BL.FilterByCategoryID(ID);
            return Result;
        }

        [HttpGet]
        public Product RetrieveProductById(int ID)
        {
            var BL = new Products();
            var Result = BL.RetriveById(ID);
            return Result;
        }

        [HttpPost]
        public bool UpdateProduct(Product productToUpdate)
        {
            var BL = new Products();
            var Result = BL.Update(productToUpdate);
            return Result;
        }

        //TODOS LOS METODOS DE PRODUCT IMPLEMENTADOS.
        //TODO: Implementar los de CATEGORY.
        [HttpPost]
        public Category CreateCategory(Category newCategory)
        {
            var BL = new Categories();
            var NewCategory = BL.Create(newCategory);
            return NewCategory;
        }

        [HttpGet]
        public bool DeleteCategory(int ID)
        {
            var BL = new Categories();
            var Result = BL.Delete(ID);
            return Result;
        }

        [HttpGet]
        public List<Category> FilterByCategoryID(int ID)
        {
            var BL = new Categories();
            var Result = BL.FilterByCategoryID(ID);
            return Result;
        }

        [HttpGet]
        public Category RetrieveCategoryById(int ID)
        {
            var BL = new Categories();
            var Result = BL.RetriveById(ID);
            return Result;
        }

        [HttpPost]
        public bool UpdateCategory(Category categoryToUpdate)
        {
            var BL = new Categories();
            var Result = BL.Update(categoryToUpdate);
            return Result;
        }

    }
}
