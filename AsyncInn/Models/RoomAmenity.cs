namespace Async_Inn.Models
{
    public class RoomAmenity
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        public RoomStyle Room { get; set; }
        public Amenity Amenity { get; set; }

    }
}
