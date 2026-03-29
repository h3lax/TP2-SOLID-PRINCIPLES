namespace HotelReservation.Application;

using HotelReservation.Domain;

// ISP VIOLATION: This interface is too large. HousekeepingService only needs
// GetByDateRange, BillingService only needs GetById and GetTotalRevenue,
// yet both depend on all 9 methods.

/**
*   For Admin and managers
*/
public interface IReservationManaging
{
    Reservation? GetById(string id);
    List<Reservation> GetAll();
    List<Reservation> GetByGuest(string guestName);
    void Add(Reservation reservation);
    void Update(Reservation reservation);
    void Delete(string id);
    void Reset();
    List<Reservation> GetByDateRange(DateTime from, DateTime to); // obligé de laisser la methode, utilisée par le dependancy injector
}

/**
*   For Housekeeping and external needs 
*/
public interface IReservationReading
{
    List<Reservation> GetByDateRange(DateTime from, DateTime to);
}

/**
*   For Finacial needs
*/
public interface IReservationFinancials
{
    decimal GetTotalRevenue(DateTime from, DateTime to);
    Dictionary<string, int> GetOccupancyStats(DateTime from, DateTime to);
}
