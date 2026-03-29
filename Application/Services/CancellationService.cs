namespace HotelReservation.Application;

using HotelReservation.Domain;

// OCP VIOLATION: Adding a new cancellation policy (e.g., "SuperFlexible")
// requires opening this class and adding a new case to the switch.
public class CancellationService
{
public void CancelReservation(Reservation reservation, DateTime now)
    {
        var policy = CancellationPolicyResolver.GetPolicy(reservation.CancellationPolicy);
        
        var refund = policy.CalculateRefund(reservation, now);
        reservation.Cancel();

        Console.WriteLine(
            $"[OK] Reservation {reservation.Id} cancelled " +
            $"({policy.Name} policy: " +
            $"{(refund == reservation.TotalPrice ? "full" : "partial")} refund of {refund:F2} EUR)");
    }
}
