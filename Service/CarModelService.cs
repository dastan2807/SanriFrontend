using SanriJP.API.DataContext;
using SanriJP.API.Models;
using SanriJP.API.Repositories;

namespace SanriJP.API.Service
{
    public interface ICarModelService : IRepositoryBase<CarModel> { }
    public class CarModelService : RepositoryBase<CarModel>, ICarModelService
    {
        private readonly AppDbContext _db;
        public CarModelService(AppDbContext db) : base(db) => _db = db;
    }
}
