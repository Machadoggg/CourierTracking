using CourierTracking.Application.Interfaces;
using CourierTracking.Domain.Entities;
using CourierTracking.Domain.Interfaces;

namespace CourierTracking.Infrastructure.Services
{
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
