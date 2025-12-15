using Hotel.Models;
using Hotel.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Hotel.Repository
{
    internal class RoomRepository : IRepository<Room, int>
    {
        private readonly AppDbContext _db;

        public RoomRepository(AppDbContext db)
        {
            _db = db;
        }

        public Room? Add(Room entity)
        {
            EntityEntry<Room> roomEntity = _db.Add(entity);
            _db.SaveChanges();
            return roomEntity.Entity;
        }

        public bool Delete(int id)
        {
            var room = GetById(id);
            if (room is null)
                return false;

            _db.Remove(room);
            return _db.SaveChanges() == 1;
        }

        public List<Room> GetAll()
        {
            return _db.Rooms.ToList();
        }

        public Room? GetById(int id)
        {
            return _db.Rooms.Find(id);
        }

        public Room? Update(int id, Room entity)
        {
            var roomFind = GetById(id);
            if (roomFind is null)
                return null;

            if (roomFind.Number != entity.Number)
                roomFind.Number = entity.Number;
            if (roomFind.Status != entity.Status)
                roomFind.Status = entity.Status;
            if (roomFind.BedCount != entity.BedCount)
                roomFind.BedCount = entity.BedCount;
            if (roomFind.PricePerNight != entity.PricePerNight)
                roomFind.PricePerNight = entity.PricePerNight;

            _db.SaveChanges();
            return roomFind;
        }
    }
}
