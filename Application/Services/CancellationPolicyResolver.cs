namespace HotelReservation.Application;

using HotelReservation.Domain;

public static class CancellationPolicyResolver
{
    public static ICancellationPolicy GetPolicy(string policyName)
    {
        return policyName switch
        {
            "Flexible" => new FlexiblePolicy(),
            "Moderate" => new ModeratePolicy(),
            "Strict" => new StrictPolicy(),
            "NonRefundable" => new NonRefundablePolicy(),
            _ => throw new ArgumentException($"Unknown policy: {policyName}")
        };
    }
}