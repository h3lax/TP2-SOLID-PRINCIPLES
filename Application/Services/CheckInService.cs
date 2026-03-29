namespace HotelReservation.Application;

using HotelReservation.Domain;

// SRP VIOLATION (Example 2): A single method mixes multiple levels of abstraction.
// High-level business rules sit next to low-level cache manipulation and config reading.
public class CheckInService (
    CheckInLogic checkInLogic,
    ISmsNotificationService notifier
    ) : ICheckInService
{

    // // I know I'll have to remove these local privates _cache & _dataStore handling later also I'll remove the class builder since I'm using the dependancy injection now
    // private readonly Dictionary<string, CacheEntry> _cache = new();
    // private readonly Dictionary<string, Reservation> _dataStore;

    // public CheckInService(Dictionary<string, Reservation> dataStore)
    // {
    //     _dataStore = dataStore;
    // }

    public void ProcessCheckIn(Reservation reservation)
    {
        checkInLogic.ValidateCheckInStatus(reservation);

        var currentTime = DateTime.Now;
        if (checkInLogic.IsLateCheckIn(currentTime))
        {
            reservation.ApplyLateCheckInFee(25m); 
        }

        reservation.Status = "CheckedIn";

        notifier.SendSms(reservation.RoomId, "occupied");
    }

    public void ProcessCheckOut(Reservation reservation)
    {
        checkInLogic.ValidateCheckOutStatus(reservation);

        reservation.Status = "CheckedOut";

        notifier.SendSms(reservation.RoomId, "free");
    }
}
