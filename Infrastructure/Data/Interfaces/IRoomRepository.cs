namespace HotelReservation.Infrastructure;

using HotelReservation.Domain;

public interface IRoomRepository
{
    Room? GetById(string roomId);
    List<Room> GetAvailableRooms(DateTime from, DateTime to);
    void SeedRooms(List<Room> rooms);
    void Save(Room room);
}
