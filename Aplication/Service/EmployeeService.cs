using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Configuration;
using Domain.Repository;
using Domain.Entities;
using Aplication.Base;
using System.Net;
using AutoMapper;

namespace Aplication.Service
{
    public class EmployeeService : CustomService<Employee>, Helpers.IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWorkRepository unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _employeeRepository = unitOfWork.EmployeeRepository;
        }
        public async Task<Response<List<EmployeeDto>>> GetAllEmployee()
        {
            List<EmployeeDto> listEmployee = _mapper.Map<List<EmployeeDto>>(await _employeeRepository.GetAll());
            return Response<List<EmployeeDto>>.CreateResponseSuccess(listEmployee, HttpStatusCode.OK, "Empleados consultados correctamente");
        }
    }
}
