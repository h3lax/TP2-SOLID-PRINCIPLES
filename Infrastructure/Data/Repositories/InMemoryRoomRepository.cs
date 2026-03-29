namespace HotelReservation.Infrastructure;

using HotelReservation.Domain;

public class InMemoryRoomRepository : IRoomRepository
{
    private readonly Dictionary<string, Room> _rooms = new();
    private readonly IReservationManaging _reservationRepo;

    public InMemoryRoomRepository(IReservationManaging reservationRepo)
    {
        _reservationRepo = reservationRepo;
    }

    public void SeedRooms(List<Room> rooms)
    {
        foreach (var room in rooms)
            _rooms[room.Id] = room;
    }

    public Room? GetById(string roomId)
    {
        return _rooms.TryGetValue(roomId, out var room) ? room : null;
    }

    public List<Room> GetAvailableRooms(DateTime from, DateTime to)
    {
        var reservedRoomIds = _reservationRepo.GetByDateRange(from, to)
            .Select(r => r.RoomId)
            .ToHashSet();

        return _rooms.Values
            .Where(r => !reservedRoomIds.Contains(r.Id))
            .ToList();
    }

    public void Save(Room room)
    {
        _rooms[room.Id] = room;
    }
}
