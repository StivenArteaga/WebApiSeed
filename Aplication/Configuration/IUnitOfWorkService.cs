using Aplication.Helpers;

namespace Aplication.Configuration
{
    public interface IUnitOfWorkService
    {
        IEmployeeService EmployeeService { get;  }
    }
}
