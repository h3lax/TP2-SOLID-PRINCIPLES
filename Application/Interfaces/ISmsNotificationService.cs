namespace HotelReservation.Application;

// ISP VIOLATION: BookingService only sends emails, HousekeepingService only
// sends SMS, yet both depend on this interface with 4 methods.
public interface ISmsNotificationService
{
    void SendSms(string roomId, string state);
}