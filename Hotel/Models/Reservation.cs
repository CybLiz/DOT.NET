using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public enum ReservationStatus
        {
            Pending,
            Confirmed,
            Cancelled,
            Completed
        }
        public ReservationStatus Status { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Client? Guest { get; set; }
        public Room? ReservedRoom { get; set; }

        public override string ToString()
        {
            return $"Reservation {Id}: {Guest}, Room {ReservedRoom?.Number}, {Status}, Check-in: {CheckInDate.ToShortDateString()}, Check-out: {CheckOutDate.ToShortDateString()}";
        }
    }
}
