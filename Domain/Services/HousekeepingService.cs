namespace HotelReservation.Domain;

using HotelReservation.Infrastructure;

// DIP VIOLATION (Example 2): High-level housekeeping logic directly depends on
// low-level EmailSender. If we want to notify by SMS instead, we must modify this class.
public class HousekeepingService
(
    ICleaningNotifier notifier
)
{
    // Direct dependency on concrete EmailSender
    private readonly EmailSender _emailSender = new();

    public List<CleaningTask> GenerateLinenChangeSchedule(Reservation reservation)
    {
        var tasks = new List<CleaningTask>();
        var current = reservation.CheckIn.AddDays(3);
        while (current < reservation.CheckOut)
        {
            tasks.Add(new CleaningTask
            {
                RoomId = reservation.RoomId,
                Date = current,
                Type = "LinenChange",
                HousekeeperEmail = "housekeeping@masdesoliviers.fr",
                Time = new TimeSpan(10, 0, 0)
            });
            current = current.AddDays(3);
        }
        return tasks;
    }

    public void NotifyHousekeeper(CleaningTask task)
    {
        notifier.GenerateNotification(
            task.HousekeeperEmail,
            $"Room {task.RoomId} needs {task.Type} on {task.Date:dd/MM/yyyy}");
    }
}
