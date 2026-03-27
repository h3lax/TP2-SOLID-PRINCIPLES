namespace HotelReservation.Domain;

/**
* Gère les règles BUSINESS
*/
public class ReservationLogic
{
    public bool IsRoomAvailable(Room room, DateTime checkIn, DateTime checkOut, IEnumerable<Reservation> existingBookings)
    {
        return !existingBookings.Any(r => 
            r.RoomId == room.Id &&
            r.Status != "Cancelled" && 
            checkIn < r.CheckOut && 
            checkOut > r.CheckIn);
    }

    public void ValidateBooking(Room room, int guestCount, DateTime checkIn, DateTime checkOut)
    {
        if (checkIn >= checkOut) 
            throw new InvalidBookingDatesException();
        
        if (!room.CanAccommodate(guestCount))
            throw new OverCapacityException(room.MaxGuests);
    }

    public decimal CalculateReservationPrice(Room room, DateTime checkIn, DateTime checkOut)
    {
        var nightsBooked = (checkOut - checkIn).Days;
        if (nightsBooked <= 0) return 0; //TODO : faire une erreur spécifique
        return room.CalculatePrice(nightsBooked);
    }
}