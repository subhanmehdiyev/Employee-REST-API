using AutoMapper;
using EmployeeRestAPI.Data;
using EmployeeRestAPI.Repository;

namespace EmployeeRestAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }

        private readonly EmployeeDbContext _context;

        public UnitOfWork(EmployeeDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(context);
        }

        public async Task SaveAllChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
