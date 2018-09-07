using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //CRUD
    public interface IRepository:IDisposable
    {
        //PARA AGREGAR UNA ENTIDAD A LA BASE DE DATOS
        TEntity Create<TEntity>(TEntity toCreate) where TEntity : class;

        //PARA ELIMINAR UNA ENTIDAD 
        bool Delete<TEntity>(TEntity toDelete) where TEntity : class;

        //PARA MODIFICAR UNA ENTIDAD 
        bool Update<TEntity>(TEntity toUpdate) where TEntity : class;

        //PARA RECUPERAR UNA ENTIDAD EN BASE A UN CRITERIO
        TEntity Retrieve<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        //PARA RECUPERAR UN CONJUNTO DE ENTIDADES EN BASE A UN CRITERIO
        List<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
    }
}
