using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, DOB: {DateOfBirth}, Age: {Age}, Email: {Email}, Phone: {PhoneNumber}";
        }


    }
}
