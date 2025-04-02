using Microsoft.EntityFrameworkCore;
using CourierTracking.Domain.Interfaces;
using CourierTracking.Domain.Entities;
using CourierTracking.Application.Interfaces;

namespace CourierTracking.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
        public async Task UpdateAsync(T entity) => _dbContext.Set<T>().Update(entity);
        public async Task DeleteAsync(T entity) => _dbContext.Set<T>().Remove(entity);
    }

    

    // Services/CourierService.cs
    public class CourierService : ICourierService
    {
        private readonly IRepository<Courier> _courierRepository;
        private readonly IRepository<LocationHistory> _locationRepository;

        public CourierService(
            IRepository<Courier> courierRepository,
            IRepository<LocationHistory> locationRepository)
        {
            _courierRepository = courierRepository;
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Courier>> GetAllCouriersAsync() =>
            await _courierRepository.GetAllAsync();

        public async Task<Courier> GetCourierByIdAsync(int id) =>
            await _courierRepository.GetByIdAsync(id);

        public async Task UpdateCourierLocationAsync(int courierId, double latitude, double longitude, double? speed)
        {
            var location = new LocationHistory
            {
                CourierId = courierId,
                Latitude = latitude,
                Longitude = longitude,
                Speed = speed,
                Timestamp = DateTime.UtcNow
            };

            await _locationRepository.AddAsync(location);
        }

        public async Task<IEnumerable<LocationHistory>> GetCourierLocationHistoryAsync(int courierId)
        {
            var locations = await _locationRepository.GetAllAsync();
            return locations.Where(l => l.CourierId == courierId).OrderByDescending(l => l.Timestamp);
        }
    }
}

