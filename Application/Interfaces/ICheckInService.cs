namespace HotelReservation.Application;

using HotelReservation.Domain;

public interface ICheckInService 
{
    void ProcessCheckIn(Reservation reservation);
    void ProcessCheckOut(Reservation reservation);
}