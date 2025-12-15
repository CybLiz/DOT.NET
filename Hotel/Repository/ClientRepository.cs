using Hotel.Models;
using Hotel.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Hotel.Repository
{
    internal class ClientRepository : IRepository<Client, int>
    {
        private readonly AppDbContext _db;

        public ClientRepository(AppDbContext db)
        {
            _db = db;
        }

        public Client? Add(Client entity)
        {
            EntityEntry<Client> clientEntity = _db.Add(entity);
            _db.SaveChanges();
            return clientEntity.Entity;
        }

        public bool Delete(int id)
        {
            var client = GetById(id);
            if (client is null)
                return false;

            _db.Remove(client);
            return _db.SaveChanges() == 1;
        }

        public List<Client> GetAll()
        {
            return _db.Clients.ToList();
        }

        public Client? GetById(int id)
        {
            return _db.Clients.Find(id);
        }

        public Client? Update(int id, Client entity)
        {
            var clientFind = GetById(id);
            if (clientFind is null)
                return null;

            if (clientFind.FirstName != entity.FirstName)
                clientFind.FirstName = entity.FirstName;
            if (clientFind.LastName != entity.LastName)
                clientFind.LastName = entity.LastName;
            if (clientFind.PhoneNumber != entity.PhoneNumber)
                clientFind.PhoneNumber = entity.PhoneNumber;

            _db.SaveChanges();
            return clientFind;
        }
    }
}
