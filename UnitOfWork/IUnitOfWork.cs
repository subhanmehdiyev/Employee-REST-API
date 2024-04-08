using AutoMapper;
using EmployeeRestAPI.Repository;

namespace EmployeeRestAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public Task SaveAllChangesAsync();
    }
}
