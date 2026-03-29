namespace HotelReservation.Domain;

// LSP VIOLATION (Example 1): NonRefundableReservation implements this interface
// but throws on Cancel(), breaking the substitution principle.
public interface ICancellableReservation
{
    string Id { get; }
    string GuestName { get; }
    string Status { get; }
    decimal TotalPrice { get; }
    void Cancel();
    decimal CalculateRefund();
}
