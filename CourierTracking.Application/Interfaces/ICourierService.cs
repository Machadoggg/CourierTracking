using CourierTracking.Domain.Entities;

namespace CourierTracking.Application.Interfaces
{
    public interface ICourierService
    {
        Task<IEnumerable<Courier>> GetAllCouriersAsync();
        Task<Courier> GetCourierByIdAsync(int id);
        Task UpdateCourierLocationAsync(int courierId, double latitude, double longitude, double? speed);
        Task<IEnumerable<LocationHistory>> GetCourierLocationHistoryAsync(int courierId);
    }
}
