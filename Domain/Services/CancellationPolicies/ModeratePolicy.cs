
namespace HotelReservation.Domain;
public class ModeratePolicy : ICancellationPolicy
{
    public string Name => "Moderate";
    public decimal CalculateRefund(Reservation res, DateTime now)
    {
        var days = (res.CheckIn - now).Days;
        if (days >= 5) return res.TotalPrice;
        if (days >= 2) return res.TotalPrice * 0.5m;
        return 0m;
    }
}