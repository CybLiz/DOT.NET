using ContactList.Data;
using ContactList.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactList.Respository
{
    internal class ContactRepository : GenericRepo<Contact, int>
    {
        private readonly AppDbContext _db;

        public ContactRepository (AppDbContext db)
        {
            _db = db;
        }

        public Contact? Add(Contact entity)
        {
            EntityEntry<Contact> contactEntity = _db.Add(entity);
            _db.SaveChanges();
            return contactEntity.Entity;
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);
            if (contact is null)
                return false;

            _db.Remove(contact);
            return _db.SaveChanges() == 1;

        }

        public List<Contact> GetAll()
        {
            return _db.Contacts.ToList();
        }

        public Contact? GetById(int id)
        {
            return _db.Contacts.Find(id);
        }

        public Contact? Update(int id, Contact entity)
        {
            var contactFind = GetById(id);
            if (contactFind is null)
                return null;

            if (contactFind.FirstName != entity.FirstName)
                contactFind.FirstName = entity.FirstName;


            if (contactFind.LastName != entity.LastName)
                contactFind.LastName = entity.LastName;

            if (contactFind.Age != entity.Age)
                contactFind.Age = entity.Age;
           
            if (contactFind.DateOfBirth != entity.DateOfBirth)
                contactFind.DateOfBirth = entity.DateOfBirth;

            if (contactFind.Gender != entity.Gender)
                contactFind.Gender = entity.Gender;

            if (contactFind.PhoneNumber != entity.PhoneNumber)
                contactFind.PhoneNumber = entity.PhoneNumber;

            if (contactFind.Email != entity.Email)
                contactFind.Email = entity.Email;

            _db.SaveChanges();
            return contactFind;
        }
    }
}
