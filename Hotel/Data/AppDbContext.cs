using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Models;


namespace Hotel.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<Models.Client> Clients { get; set; }
        public DbSet<Models.Room> Rooms { get; set; }
        public DbSet<Models.Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=Hotel;User ID=root;Password=password;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }




    }


}
