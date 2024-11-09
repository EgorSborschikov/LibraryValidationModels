using LibraryApp.Models;

namespace LibraryApp.Interfaces
{
    public interface InterfaceReservationService
    {
        bool ReserveBook(Reservation reservation);
        void Reserve(Reservation reservation);
    }
}