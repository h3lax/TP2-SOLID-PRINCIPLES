namespace HotelReservation.Domain;

/**
*   Méthodes réservées à la gouvernante, ne fait pas de modifications sur la class Réservation
*/
public class HousekeepingScheduler
{
    public List<DateTime> GetLinenChangeDays(Reservation res)
    {
        var days = new List<DateTime>();
        var current = res.CheckIn.AddDays(3);
        while (current < res.CheckOut)
        {
            days.Add(current);
            current = current.AddDays(3);
        }
        return days;
    }
}