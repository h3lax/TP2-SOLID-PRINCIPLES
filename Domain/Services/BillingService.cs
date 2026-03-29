namespace HotelReservation.Domain;

using HotelReservation.Application; // not clean but not asked x)

// ISP VIOLATION: Depends on IReservationRepository (9 methods) but only uses
// GetById and GetTotalRevenue.
public class BillingService
{
    private readonly IReservationFinancials _repo;

    public BillingService(IReservationFinancials repo)
    {
        _repo = repo;
    }

    public decimal GetRevenueForPeriod(DateTime from, DateTime to)
    {
        return _repo.GetTotalRevenue(from, to);
    }
}
