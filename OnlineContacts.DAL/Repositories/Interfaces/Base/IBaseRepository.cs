using OnlineContacts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {

        void Add(TEntity entity);
        void Update(TEntity entity);
        void DeleteByID(object Id);
        TEntity GetById(object Id);
        IQueryable<TEntity> GetForGrid(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, Object>>[] includes);
        int SaveDbChanges();
    }
}
