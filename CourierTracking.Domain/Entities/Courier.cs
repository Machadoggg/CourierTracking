namespace CourierTracking.Domain.Entities
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string VehicleType { get; set; } = default!;
        public bool IsActive { get; set; } = true;


        public LocationHistory LastLocation { get; set; } = default!;
    }
}
