using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    internal class Room
    {

        [Key] 
       public int Number { get; set; }
       public enum StatusType
        {
            Available,
            Occupied,
            Maintenance
        }
        public StatusType Status { get; set; }
        public int BedCount { get; set; }
        public decimal PricePerNight { get; set; }
        public override string ToString()
        {
            return $"Room {Number}: {BedCount} beds, {Status}, ${PricePerNight}/night";
        }

    }
}
