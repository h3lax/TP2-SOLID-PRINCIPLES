namespace HotelReservation.Domain;

public interface ICleaningNotifier
{
    public void GenerateNotification(string coordonates, string body);
}