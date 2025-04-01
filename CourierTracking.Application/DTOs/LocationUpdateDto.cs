namespace CourierTracking.Application.DTOs
{
    public class LocationUpdateDto
    {
        public int CourierId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Speed { get; set; }
    }
}
