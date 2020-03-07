using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        #region Properties
        private readonly IDbSet<TEntity> dbSet;
        protected OnlienContactContext OnlienContactContext { get; set; }

      
        #endregion

        public BaseRepository()
        {
            OnlienContactContext = new OnlienContactContext();
            dbSet = OnlienContactContext.Set<TEntity>();

        }
        public BaseRepository(OnlienContactContext OnlienContactContext)
        {
            this.OnlienContactContext = OnlienContactContext;
            dbSet = OnlienContactContext.Set<TEntity>();

        }

        #region Implelmntations
        public virtual void Add(TEntity entity)
        {

            dbSet.Add(entity);

        }
        public virtual void Update(TEntity entity)
        {

            dbSet.Attach(entity);
            OnlienContactContext.Entry(entity).State = EntityState.Modified;

        }
        public virtual void DeleteByID(object Id)
        {
            var entity = dbSet.Find(Id);
            dbSet.Remove(entity);
        }
        public virtual TEntity GetById(object Id) => dbSet.Find(Id);
        public virtual IQueryable<TEntity> GetForGrid(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, Object>>[] includes)
        {


            IQueryable<TEntity> query = dbSet;

            if (where != null)
                query = query.Where(where);

            if (includes != null)
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            return query.AsNoTracking();

        }
        public virtual int SaveDbChanges() => OnlienContactContext.SaveChanges();
        public void Dispose()=> this.OnlienContactContext.Dispose();
        #endregion

    }
}
