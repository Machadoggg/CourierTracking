namespace CourierTracking.Domain.Entities
{
    public class LocationHistory
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public Courier Courier { get; set; } = default!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public double? Speed { get; set; }
    }
}
