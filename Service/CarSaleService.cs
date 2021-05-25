using Microsoft.EntityFrameworkCore;
using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SanriJP.API.Service
{
    public interface ICarSaleService : IRepositoryBase<CarSale> { }
    public class CarSaleService : RepositoryBase<CarSale>, ICarSaleService
    {
        private readonly AppDbContext _db;
        public CarSaleService(AppDbContext db) : base(db) => _db = db;

        public override async Task<List<CarSale>> GetAllAsync()
        {
            return await _db.CarSales
                .Include(x => x.OwnerClient)
                .Include(x => x.Auction)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
