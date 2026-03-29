namespace HotelReservation.Infrastructure;

using HotelReservation.Domain;

public class EmailCleaningNotifier(EmailSender emailSender) : ICleaningNotifier
{
    public void GenerateNotification(string coordonates, string body)
    {
        emailSender.Send(
            coordonates,
            "New cleaning task",
            body
        );
    }
}