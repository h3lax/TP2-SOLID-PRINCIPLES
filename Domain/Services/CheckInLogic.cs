namespace HotelReservation.Domain;

/**
* Gère les règles BUSINESS
*/
public class CheckInLogic
{
    public void ValidateCheckInStatus(Reservation reservation)
    {
        if (reservation.Status != "Confirmed")
            throw new WrongStatusReservation(reservation.Status);

    }

    public bool IsLateCheckIn(DateTime time)
    {
        return time.Hour >= 22;
    }

    public void ValidateCheckOutStatus(Reservation reservation)
    {
        if (reservation.Status != "CheckedIn")
            throw new WrongStatusReservation(reservation.Status);

    }    

}