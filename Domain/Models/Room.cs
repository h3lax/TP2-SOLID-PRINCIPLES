namespace HotelReservation.Domain;

public class Room
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Standard", "Suite", "Family"
    public int MaxGuests { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; } = true;

    public decimal CalculatePrice(int nightsBooked)
    {
        return PricePerNight * nightsBooked;
    }
    
    public bool CanAccommodate(int guestCount)
    {
        return guestCount <= MaxGuests;
    }
}