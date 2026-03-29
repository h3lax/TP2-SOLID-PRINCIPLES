namespace HotelReservation.Domain;

public interface ICancellationPolicy
{
    string Name { get; }
    decimal CalculateRefund(Reservation reservation, DateTime now);
}