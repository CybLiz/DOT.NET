using ContactList.Models;
using ContactList.Respository;
using System;
using ContactList.Data;

using var dbContext = new AppDbContext();

var repo = new ContactRepository(dbContext);

Contact contact = new Contact() { FirstName = "nom", LastName = "prenom", Age = 12 };

//repo.Add(contact);  

Console.WriteLine(repo.GetAll());
contact.PhoneNumber = "0128378901273";

repo.Update(1, contact);
