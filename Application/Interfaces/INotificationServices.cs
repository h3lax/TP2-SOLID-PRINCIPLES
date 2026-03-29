namespace HotelReservation.Application;

// ISP VIOLATION: BookingService only sends emails, HousekeepingService only
// sends SMS, yet both depend on this interface with 4 methods.

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public interface ISmsService
{
    void SendSms(string phoneNumber, string message);
}

public interface IPushNotificationService
{
    void SendPushNotification(string deviceId, string message);
}

public interface ISlackMessageService
{
    void SendSlackMessage(string channel, string message);
}