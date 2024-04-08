using EmployeeRestAPI.Data.Entities;

namespace EmployeeRestAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> GetEmployee(int id);
        Task<Employee> CreatEmployee(Employee newEmployee);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);    
        Task<Employee> DeleteEmployee(int id);
    }
}
