namespace HotelReservation.Infrastructure;

using HotelReservation.Application;

// Simulates file-based logging (uses Console for demo purposes).
// The SOLID violation is the direct coupling, not the I/O mechanism.
public class FileLogger : IFileLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
    public void Error(Exception ex)
    {
        Console.WriteLine($"[LOG_ERROR] {ex.Message}");
    }
}
