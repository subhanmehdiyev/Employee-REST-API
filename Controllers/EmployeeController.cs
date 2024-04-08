using AutoMapper;
using EmployeeRestAPI.Data.Entities;
using EmployeeRestAPI.Models;
using EmployeeRestAPI.Repository;
using EmployeeRestAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRestAPI.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllEmployee();

            return Ok(employees);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute]int Id)
        { 
            var employee = await _unitOfWork.EmployeeRepository.GetEmployee(Id);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> Creat([FromQuery] EmployeeModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);

            await _unitOfWork.EmployeeRepository.CreatEmployee(employee);
            await _unitOfWork.SaveAllChangesAsync();
            return Created($"api/v1/employees/{employee.ID}", employee);
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Update([FromQuery] EmployeeForUpdatingModel employeeModel)
        {
            var employee = _mapper.Map<Employee>(employeeModel);

            var updatedEmployee = await _unitOfWork.EmployeeRepository.UpdateEmployee(employee);
            await _unitOfWork.SaveAllChangesAsync();

            if (updatedEmployee is null)
                return NotFound();

            return Ok(updatedEmployee);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var deletedEmployee = await _unitOfWork.EmployeeRepository.DeleteEmployee(Id);
            await _unitOfWork.SaveAllChangesAsync();

            if (deletedEmployee is null)
                return NotFound();

            return Ok(deletedEmployee);
        }

    }
}
