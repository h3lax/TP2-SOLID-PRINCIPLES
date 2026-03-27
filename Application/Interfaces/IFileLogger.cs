namespace HotelReservation.Application ;


public interface IFileLogger
{
    public void Log (string message) ;
    public void Error (Exception exception) ;
}
