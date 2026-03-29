namespace HotelReservation.Infrastructure;

using HotelReservation.Application;
using HotelReservation.Domain;

public static class DependencyConfig
{
    private static readonly IReservationRepository _resRepo = new InMemoryReservationRepository();
    private static readonly IRoomRepository _roomRepo = new InMemoryRoomRepository(_resRepo);
    private static readonly IFileLogger _logger = new FileLogger();
    private static readonly ReservationLogic _reservationlogic = new(); // voir rajouter une interface? ou rendre static?
    private static readonly CheckInLogic _checkInlogic = new();


    public static ReservationService GetReservationService()
    {
        return new ReservationService(_logger, _roomRepo, _resRepo, _reservationlogic);
    }

    public static CancellationService GetCancellationService()
    {
        return new CancellationService();
    }

    public static ICheckInService GetCheckInService()
    {
        var notifier = new SmsNotificationService();
        // decorator avec le cache
        var appService = new CheckInService(_checkInlogic, notifier);

        return new CachedCheckInService(appService);
    }
    
    public static void InitData(List<Room> rooms)
    {
        _roomRepo.SeedRooms(rooms);
    }
}