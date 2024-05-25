using BookingManager.Enums;

namespace BookingManager.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Guests { get; set; }
        public int BedRooms { get; set;}
        public int NumberOfRooms { get; set;}
        public decimal Price { get; set; }
        public ApartmentStatus Status { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PrimaryImageUrl { get; set; }
        public string[]? Images { get; set; }
        public string[]? Facilities { get; set; }

        public Apartment(string companyName, string name, string? description, int guests, int bedRooms, int numberOfRooms, decimal price, string city, string state, string country, string primaryImageUrl, string[]? images, string[]? facilities)
        {
            CompanyName = companyName;
            Name = name;
            Description = description;
            Guests = guests;
            BedRooms = bedRooms;
            NumberOfRooms = numberOfRooms;
            Price = price;
            Status = ApartmentStatus.Available;
            City = city;
            State = state;
            Country = country;
            PrimaryImageUrl = primaryImageUrl;
            Images = images;
            Facilities = facilities;
        }

    }
}
