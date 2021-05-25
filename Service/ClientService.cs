using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;

namespace SanriJP.API.Service
{
    public interface IClientService : IRepositoryBase<Client> { }
    public class ClientService : RepositoryBase<Client>, IClientService
    {
        private readonly AppDbContext _db;
        public ClientService(AppDbContext db) : base(db) => _db = db;
    }
}
