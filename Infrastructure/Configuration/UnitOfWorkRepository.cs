using System;
using Domain.Configuration;
using Microsoft.EntityFrameworkCore.Storage;
using Domain.Repository;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;

namespace Infrastructure.Configuration
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private IDbContext _dbContext;
        private IDbContextTransaction _dbContextTransaction;

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public UnitOfWorkRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            EmployeeRepository = new EmployeeRepository(dbContext);
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = ((ApplicationContext)_dbContext).Database.BeginTransaction();
        }

        public void ClearTracking()
        {
            ((ApplicationContext)_dbContext).ChangeTracker.Clear();
        }

        public void Commit()
        {
            try
            {
                _dbContextTransaction?.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error  en {nameof(UnitOfWorkRepository)}.{CallerMember.GetNameMethod()}: {ex.Message}", ex);
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            ((DbContext)_dbContext).Dispose();
            _dbContext = null;
        }

        public void RollBack()
        {
            _dbContextTransaction?.Rollback();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error  en {nameof(UnitOfWorkRepository)}.{CallerMember.GetNameMethod()}: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}
