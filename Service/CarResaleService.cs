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
    public interface ICarResaleService : IRepositoryBase<CarResale> { }
    public class CarResaleService : RepositoryBase<CarResale>, ICarResaleService
    {
        private readonly AppDbContext _db;
        public CarResaleService(AppDbContext db) : base(db) => _db = db;

        public override async Task<List<CarResale>> GetAllAsync()
        {
            return await _db.CarResales
                .Include(x => x.OwnerClient)
                .Include(x => x.CarOrder)
                .Include(x => x.NewClient)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
