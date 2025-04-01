using Microsoft.AspNetCore.SignalR;

namespace CourierTracking.API.Hubs
{
    public class LocationHub : Hub
    {
        public async Task SendLocationUpdate(int courierId, double latitude, double longitude, double? speed)
        {
            await Clients.All.SendAsync("ReceiveLocationUpdate", courierId, latitude, longitude, speed);
        }
    }
}
