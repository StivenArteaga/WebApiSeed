using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Helpers
{
    public interface IEmployeeService
    {
        Task<Response<List<EmployeeDto>>> GetAllEmployee();
    }
}
