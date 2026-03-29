
namespace HotelReservation.Domain;
public class StrictPolicy : ICancellationPolicy
{
    public string Name => "Moderate";
    public decimal CalculateRefund(Reservation res, DateTime now)
    {
        var days = (res.CheckIn - now).Days;
        if (days >= 14) return res.TotalPrice;
        if (days >= 7) return res.TotalPrice * 0.5m;
        return 0m;
    }
}