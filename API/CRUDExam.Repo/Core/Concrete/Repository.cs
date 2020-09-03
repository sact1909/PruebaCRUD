using CRUDExam.Data.Models;
using CRUDExam.Repo.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Core.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        internal DbSet<TEntity> DbSet;
        public Repository(AppDbContext context)
        {
            this._context = context;
            DbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        

        public bool IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Any(expression);
        }

        public async Task<List<TEntity>> FindBy(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetByIDAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public TEntity GetByID(Expression<Func<TEntity, bool>> expression)
        {
            return  _context.Set<TEntity>().Where(expression).FirstOrDefault();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            //_context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            //await _context.Set<TEntity>().ToListAsync();

            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
            //return query.ToListAsync();
        }


        public async Task RemoveAsync(TEntity entityToDelete)
        {
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public async Task RemoveAsync(object Id)
        {
            TEntity entityToDelete = DbSet.Find(Id);
            await RemoveAsync(entityToDelete);
        }

        public Task RemoveRange(List<TEntity> entityToDelete)
        {
            throw new NotImplementedException();
        }
    }
}
