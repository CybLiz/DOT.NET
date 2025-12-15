using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Hotel.Repository
{
    internal class ReservationRepository : IRepository<Reservation, int>
    {
        private readonly AppDbContext _db;

        public ReservationRepository(AppDbContext db)
        {
            _db = db;
        }

        public Reservation? Add(Reservation entity)
        {
            EntityEntry<Reservation> reservationEntity = _db.Add(entity);
            _db.SaveChanges();
            return reservationEntity.Entity;
        }

        public bool Delete(int id)
        {
            var reservation = GetById(id);
            if (reservation is null)
                return false;

            _db.Remove(reservation);
            return _db.SaveChanges() == 1;
        }

        public List<Reservation> GetAll()
        {
            return _db.Reservations
                .Include(r => r.Guest)
                .Include(r => r.ReservedRoom)
                .ToList();
        }

        public Reservation? GetById(int id)
        {
            return _db.Reservations
                .Include(r => r.Guest)
                .Include(r => r.ReservedRoom)
                .FirstOrDefault(r => r.Id == id);
        }

        public Reservation? Update(int id, Reservation entity)
        {
            var reservationFind = GetById(id);
            if (reservationFind is null)
                return null;

            if (reservationFind.Status != entity.Status)
                reservationFind.Status = entity.Status;
            if (reservationFind.CheckInDate != entity.CheckInDate)
                reservationFind.CheckInDate = entity.CheckInDate;
            if (reservationFind.CheckOutDate != entity.CheckOutDate)
                reservationFind.CheckOutDate = entity.CheckOutDate;
            if (reservationFind.Guest != entity.Guest)
                reservationFind.Guest = entity.Guest;
            if (reservationFind.ReservedRoom != entity.ReservedRoom)
                reservationFind.ReservedRoom = entity.ReservedRoom;

            _db.SaveChanges();
            return reservationFind;
        }
    }
}
