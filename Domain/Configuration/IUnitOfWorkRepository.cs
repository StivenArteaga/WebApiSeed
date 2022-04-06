using Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }

        void Commit();
        void RollBack();
        void BeginTransaction();
        void ClearTracking();
        Task SaveChangesAsync();
    }
}
