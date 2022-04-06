using Aplication;
using Aplication.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public EmployeeController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<Response<List<EmployeeDto>>>> GetAllEmployee()
        {
            var response = await _unitOfWorkService.EmployeeService.GetAllEmployee();
            return StatusCode((int)response.Code, response);
        }
    }
}
