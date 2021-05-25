using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;

namespace SanriJP.API.Service
{
    public interface IEmployeeRoleService : IRepositoryBase<EmployeeRole> { }
    public class EmployeeRoleService : RepositoryBase<EmployeeRole>, IEmployeeRoleService
    {
        private readonly AppDbContext _db;
        public EmployeeRoleService(AppDbContext db) : base(db) => _db = db;
    }
}
