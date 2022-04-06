using AutoMapper;
using Domain.Entities;

namespace Aplication.Base.Mapping
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
