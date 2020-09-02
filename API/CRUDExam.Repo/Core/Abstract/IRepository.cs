using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExam.Repo.Core.Abstract
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task Add(TEntity entityToInsert);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Update(TEntity entityToUpdate);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task Remove(TEntity entityToDelete);
        Task RemoveRange(List<TEntity> entityToDelete);
        bool IsExist(Expression<Func<TEntity, bool>> expression);

    }
}
