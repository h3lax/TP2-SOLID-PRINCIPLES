namespace HotelReservation.Infrastructure;

using HotelReservation.Application;

public class SmsNotificationService : ISmsNotificationService
{
    public void SendSms(string roomId, string state) 
        => Console.WriteLine($"[SMS] Room {roomId} is now {state}");

}