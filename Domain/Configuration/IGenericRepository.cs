using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page = 1,
          int size = int.MaxValue);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetFirst(Expression<Func<T, bool>> expression);
        Task<List<T>> GetBy(Expression<Func<T, bool>> filter = null, string propertyInclude = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task Add(T entity);
        Task AddRange(List<T> entities);
        Task Edit(T entity);
        Task Remove(T entity);
        Task RemoveRange(List<T> entities);
        Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> expression);
        Task<int> CountAll();
        Task<int> CountBy(Expression<Func<T, bool>> expression);
        Task<bool> FindRecord(Expression<Func<T, bool>> expression);
    }
}
