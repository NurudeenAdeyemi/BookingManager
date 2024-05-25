using BookingManager.Enums;

namespace BookingManager.Models
{
    public class ApartmentRequestModel
    {
        public string CompanyName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Guests { get; set; }
        public int BedRooms { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public IFormFile PrimaryImageUrl { get; set; } = null!;
        public IList<IFormFile> Images { get; set; }
        public IList<string> Facilities { get; set; }
    }
}
