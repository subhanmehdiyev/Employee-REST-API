using EmployeeRestAPI.Data;
using EmployeeRestAPI.Data.Entities;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeRestAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> CreatEmployee(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            return newEmployee;
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var employee = await _context.Employees.FindAsync(updatedEmployee.ID);

            if (employee is not null)
            {
                employee.Position = updatedEmployee.Position;
                employee.Salary = updatedEmployee.Salary;
                employee.IsManager = updatedEmployee.IsManager;

                _context.Employees.Update(employee).CurrentValues.SetValues(employee);
            }

            return updatedEmployee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            var deletedEmployee = employee;

            if (employee is not null)
            {
                _context.Employees.Remove(employee);
            }

            return deletedEmployee;
        }
    }
}
