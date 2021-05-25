using Microsoft.EntityFrameworkCore;
using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanriJP.API.Service
{
    public interface ICarOrderService : IRepositoryBase<CarOrder> { }
    public class CarOrderService : RepositoryBase<CarOrder>, ICarOrderService
    {
        private readonly AppDbContext _db;
        public CarOrderService(AppDbContext db) : base(db) => _db = db;

        public override async Task<List<CarOrder>> GetAllAsync()
        {
            return await _db.CarOrders
                .Include(x => x.Client)
                .Include(x => x.Auction)
                .AsNoTracking().ToListAsync();
        }
    }
}
