using Infrastructure.Configuration;
using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
