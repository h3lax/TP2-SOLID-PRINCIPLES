namespace HotelReservation.Application;

using HotelReservation.Infrastructure;
using HotelReservation.Application;
using HotelReservation.Domain;

// SRP VIOLATION (Example 1): This class mixes three levels of concern:
// - INFRASTRUCTURE: direct data access, logging
// - BUSINESS: availability check, price calculation, validation
// - APPLICATION: workflow orchestration
public class ReservationService (
    IFileLogger logger,
    IRoomRepository roomRepository,
    IReservationRepository reservationRepository,
    ReservationLogic reservationLogic
    )
{

    private static int _counter = 0;

    public string CreateReservation(string guestName, string roomId, DateTime checkIn,
        DateTime checkOut, int guestCount, string roomType, string email)
    {
        // INFRA: logging
        logger.Log($"[LOG] Creating reservation for {guestName}...");

        // les rooms et résas ne sont plus gérées par le ReservationService, elles sont seulement lues
        // on conserve la logique initiale un peu bancale avec le firstordefault & la verif en utilisant toutes les resas
        var reservations = reservationRepository.GetAll();
        var room = roomRepository.GetAvailableRooms(checkIn, checkOut).FirstOrDefault(r => r.Id == roomId);

        if (room == null)
            throw new RoomNotFound();

        // à voir de créer une fonction main reservationLogic qui fait tout d'un coup
        reservationLogic.ValidateBooking(room, guestCount, checkIn, checkOut);
        reservationLogic.IsRoomAvailable(room, checkIn, checkOut,  reservations);
        var total = reservationLogic.CalculateReservationPrice(room, checkIn, checkOut);


        // APPLICATION: create and store
        _counter++;
        var reservation = new Reservation
        {
            Id = $"R-{_counter:D3}",
            GuestName = guestName,
            RoomId = roomId,
            CheckIn = checkIn,
            CheckOut = checkOut,
            GuestCount = guestCount,
            RoomType = roomType,
            Status = "Confirmed",
            Email = email,
            TotalPrice = total
        };
        reservationRepository.Add(reservation);

        // INFRA: logging
        logger.Log($"[LOG] Reservation {reservation.Id} created.");

        return reservation.Id;
    }

    public Reservation? GetReservation(string id)
    {
        return reservationRepository.GetById(id);
    }

    public List<Reservation> GetAllReservations()
    {
        return reservationRepository.GetAll();
    }

    public List<Room> GetRooms(DateTime checkIn, DateTime checkOut)
    {
        return roomRepository.GetAvailableRooms(checkIn, checkOut);
    }

    public void Reset()
    {
        reservationRepository.Reset();
        _counter = 0;
    }
}
