using MagiProject.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace MagiProject.Data.Concrete
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        internal DbSet<TEntity> dbSet;
        protected readonly string lang;

        public GenericRepository(DbContext ctx)
        {
            context = ctx;
            this.dbSet = context.Set<TEntity>();
            lang = "TR";
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }
        public IQueryable<TEntity> AllDataOrderByName(Expression<Func<TEntity, bool>> _expression = null, Expression<Func<TEntity, object>> _orderBy = null, int take = 0, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (take == 0)
                return query.Where(_expression).OrderBy(_orderBy);

            return query.Where(_expression).OrderBy(_orderBy).Take(take);
        }

        public IQueryable<TEntity> AllDataList(Expression<Func<TEntity, bool>> _expression = null, Expression<Func<TEntity, object>> _orderBy = null, int take = 0, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (take == 0)
                return query.Where(_expression).OrderByDescending(_orderBy);

            return query.Where(_expression).OrderByDescending(_orderBy).Take(take);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity FirstData(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void AddRange(List<TEntity> entity)
        {
            context.Set<TEntity>().AddRange(entity);
        }

        public bool IsNameAvaible(Expression<Func<TEntity, bool>> expression)
        {
            if (context.Set<TEntity>().Any(expression))
                return true;
            return false;
        }

        public TEntity GetDataById(Expression<Func<TEntity, bool>> _expression = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                foreach (var includeProperty in includeProperties.Split
                  (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.Where(_expression).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return null;
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> FirstDataAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

    }
}
