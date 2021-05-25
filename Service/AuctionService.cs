using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;

namespace SanriJP.API.Service
{
    public interface IAuctionService : IRepositoryBase<Auction> { }
    public class AuctionService : RepositoryBase<Auction>, IAuctionService
    {
        private readonly AppDbContext _db;
        public AuctionService(AppDbContext db) : base(db) => _db = db;
    }
}
