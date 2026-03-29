
namespace HotelReservation.Domain;
public class NonRefundablePolicy : ICancellationPolicy
{
    public string Name => "NonRefundable";
    public decimal CalculateRefund(Reservation res, DateTime now) => 0m;
}