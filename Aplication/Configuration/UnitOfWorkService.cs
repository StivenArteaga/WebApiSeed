using Aplication.Helpers;
using Aplication.Service;
using AutoMapper;
using Domain.Configuration;

namespace Aplication.Configuration
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public IEmployeeService EmployeeService { get; private set; }
        public UnitOfWorkService(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            EmployeeService = new EmployeeService(unitOfWorkRepository, mapper);
        }
    }
}
