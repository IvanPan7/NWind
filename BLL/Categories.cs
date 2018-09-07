using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class Categories 
    {
        public Category Create(Category newCategory)
        {
            Category Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Buscar si el nombre del Categoryo existe
                Category res =
                    r.Retrieve<Category>(
                        p => p.CategoryName == newCategory.CategoryName);
                if (res == null)
                {
                    //No existe, entonces podemos crear.
                    Result = r.Create(newCategory);
                }
                else
                {
                    /*Podríamos aquí lanzar una excepción 
                    para notificar que el Categoryo ya existe.*/


                }
            }


            return Result;
        }
        public Category RetriveById(int ID)
        {
            Category Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Retrieve<Category>(p => p.CategoryID == ID);
            }
            return Result;

        }
        public bool Update(Category CategoryToUpdate)
        {
            bool Result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //Validar que el nombre del Categoryo no exista
                Category Temp = r.Retrieve<Category>(p => p.CategoryName == CategoryToUpdate.CategoryName && p.CategoryID != CategoryToUpdate.CategoryID);
                if (Temp == null)
                {
                    //No existe
                    Result = r.Update(CategoryToUpdate);
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
            var Category = RetriveById(ID);
            if (Category != null)
            {
                
                    //Eliminar el Categoryo
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        Result = r.Delete(Category);
                    }
                
                
            }
            else
            {
                //Indicar que el Categoryo no existe
            }

            return Result;
        }
        public List<Category> FilterByCategoryID(int categoryID)
        {
            List<Category> Result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Result = r.Filter<Category>(p => p.CategoryID == categoryID);

            }
            return Result;
        }
    }
}
