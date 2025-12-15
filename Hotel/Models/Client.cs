using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hotel.Models
{
    internal class Client
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Phone: {PhoneNumber}";
        }

    }
}
