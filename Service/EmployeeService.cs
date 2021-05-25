using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;

namespace SanriJP.API.Service
{
    public interface IEmployeeService : IRepositoryBase<Employee> { }
    public class EmployeeService : RepositoryBase<Employee>, IEmployeeService
    {
        private readonly AppDbContext _db;
        public EmployeeService(AppDbContext db) : base(db) => _db = db;
    }
}
