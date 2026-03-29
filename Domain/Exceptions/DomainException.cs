namespace HotelReservation.Domain;

public abstract class DomainException(string message) : Exception(message);

public class WrongStatusReservation(string status) 
    : DomainException($"Cannot check in: reservation is {status}");
    
public class RoomNotFound() 
    : DomainException("Unfortunately, we couldn't find a room");

public class RoomNotAvailableException(string roomId, DateTime start, DateTime end) 
    : DomainException($"Room {roomId} is already occupied from {start:dd/MM} to {end:dd/MM}.");

public class OverCapacityException(int max) 
    : DomainException($"This room cannot accommodate more than {max} guests.");

public class InvalidBookingDatesException() 
    : DomainException("Check-out date must be at least one day after check-in.");