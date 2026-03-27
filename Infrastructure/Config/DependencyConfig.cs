namespace HotelReservation.Infrastructure;

using HotelReservation.Application;
using HotelReservation.Domain;
using HotelReservation.Repositories;

public static class DependencyConfig
{
    private static readonly IReservationRepository _resRepo = new InMemoryReservationRepository();
    private static readonly IRoomRepository _roomRepo = new InMemoryRoomRepository(_resRepo);
    private static readonly IFileLogger _logger = new FileLogger();

    // voir rajouter une interface?
    private static readonly ReservationLogic _logic = new();

    public static ReservationService GetReservationService()
    {
        return new ReservationService(_logger, _roomRepo, _resRepo, _logic);
    }

    // public static CancellationService GetCancellationService()
    // {
    //     return new CancellationService(_resRepo, _logger);
    // }
    
    public static void InitData(List<Room> rooms)
    {
        _roomRepo.SeedRooms(rooms);
    }
}