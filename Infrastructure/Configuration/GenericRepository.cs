using Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Infrastructure.Configuration
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbContext _dbContext;
        public readonly DbSet<T> _dbSet;

        public GenericRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRange(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAll()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> CountBy(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).CountAsync();
        }

        public async Task Edit(T entity)
        {
            _dbContext.SetModified(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> FindRecord(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).AnyAsync();
        }

        public async Task<List<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int page = 1, int size = int.MaxValue)
        {
            return await orderBy(_dbSet).Skip((page - 1) * size).Take(size).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetBy(Expression<Func<T, bool>> filter = null, string propertyInclude = "", Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var query = GetQueryable();

            if (filter != null) query = query.Where(filter);

            query = propertyInclude.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            query = orderBy != null ? orderBy(query) : query;
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetBy(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).FirstOrDefaultAsync();
        }

        public async Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

    }
}
