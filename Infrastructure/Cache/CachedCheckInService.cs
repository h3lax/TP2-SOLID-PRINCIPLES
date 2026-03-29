namespace HotelReservation.Infrastructure;

using HotelReservation.Application;
using HotelReservation.Domain;

public class CachedCheckInService(ICheckInService appCheckInService) : ICheckInService
{
    private readonly Dictionary<string, CacheEntry> _cache = new();

    public void ProcessCheckIn(Reservation reservation)
    {
        appCheckInService.ProcessCheckIn(reservation);

        if (_cache.ContainsKey(reservation.Id))
            _cache.Remove(reservation.Id);
        _cache[reservation.Id] = new CacheEntry(DateTime.Now, "CheckedIn");
    }

    public void ProcessCheckOut(Reservation reservation)
    {
        appCheckInService.ProcessCheckOut(reservation);
        
        if (_cache.ContainsKey(reservation.Id))
            _cache.Remove(reservation.Id);
    }
}