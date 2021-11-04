namespace Async_Inn.Models.DTOs
{
    public class HotelRoomDTO
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public bool PetFriendly { get; set; }
        public bool IsHaunted { get; set; }
    }
}