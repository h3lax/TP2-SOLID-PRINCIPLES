namespace HotelReservation.Domain;
public class FlexiblePolicy : ICancellationPolicy
{
    public string Name => "Flexible";
    public decimal CalculateRefund(Reservation res, DateTime now) =>
        (res.CheckIn - now).Days >= 1 ? res.TotalPrice : 0m;
}