using Hotel.Data;
using Hotel.Models;

using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

AppDbContext db = new AppDbContext();

bool continuer = true;


    var clients = new List<Client>
    {
        new Client { FirstName = "Alice", LastName = "Martin", PhoneNumber = "0612345678" },
        new Client { FirstName = "Bob", LastName = "Durand", PhoneNumber = "0623456789" },
        new Client { FirstName = "Claire", LastName = "Petit", PhoneNumber = "0634567890" },
        new Client { FirstName = "David", LastName = "Lemoine", PhoneNumber = "0645678901" },
        new Client { FirstName = "Eva", LastName = "Moreau", PhoneNumber = "0656789012" }
    };

    db.Clients.AddRange(clients);
    db.SaveChanges();
    Console.WriteLine("Added five clients.");



    var rooms = new List<Room>
    {
        new Room { Number = 101, BedCount = 1, PricePerNight = 50, Status = Room.StatusType.Available },
        new Room { Number = 102, BedCount = 2, PricePerNight = 80, Status = Room.StatusType.Occupied },
        new Room { Number = 103, BedCount = 1, PricePerNight = 60, Status = Room.StatusType.Available },
        new Room { Number = 104, BedCount = 3, PricePerNight = 120, Status = Room.StatusType.Available },
        new Room { Number = 105, BedCount = 2, PricePerNight = 90, Status = Room.StatusType.Maintenance }
    };

    db.Rooms.AddRange(rooms);
    db.SaveChanges();
    Console.WriteLine("Added five rooms.");


while (continuer)
{
    DisplayMainMenu();
    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            ManageClients();
            break;
        case "2":
            ManageRooms();
            break;
        case "3":
            ManageReservations();
            break;
        case "0":
            continuer = false;
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
    Console.WriteLine();
}

void DisplayMainMenu()
{
    Console.WriteLine("--- MENU ---");
    Console.WriteLine("1. Manage Clients");
    Console.WriteLine("2. Manage Rooms");
    Console.WriteLine("3. Manage Reservations");
    Console.WriteLine("0. Quit");
    Console.Write("\nYour choice: ");
}

void ManageReservations()
{
    Console.WriteLine("\n--- MANAGE RESERVATIONS ---");
    Console.WriteLine("1. Add a reservation");
    Console.WriteLine("2. List all reservations");
    Console.WriteLine("3. Get reservation by ID");
    Console.WriteLine("4. Delete a reservation");
    Console.WriteLine("5. Update a reservation");
    Console.Write("\nYour choice: ");

    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1": AddReservation(); break;
        case "2": GetAllReservations(); break;
        case "3": GetReservationById(); break;
        case "4": DeleteReservation(); break;
        case "5": UpdateReservation(); break;
        default: Console.WriteLine("Invalid choice!"); break;
    }
}

// -------------------- CRUD Reservations --------------------

void AddReservation()
{
    Console.Write("Client ID: ");
    int clientId = int.Parse(Console.ReadLine());

    Console.Write("Room Number: ");
    int roomNumber = int.Parse(Console.ReadLine());

    Console.Write("Status (Pending, Confirmed, Cancelled, Completed): ");
    string statusInput = Console.ReadLine();
    Reservation.ReservationStatus status = Enum.Parse<Reservation.ReservationStatus>(statusInput);

    Console.Write("Check-in date (yyyy-MM-dd): ");
    DateTime checkIn = DateTime.Parse(Console.ReadLine());

    Console.Write("Check-out date (yyyy-MM-dd): ");
    DateTime checkOut = DateTime.Parse(Console.ReadLine());

    var client = db.Clients.Find(clientId);
    var room = db.Rooms.Find(roomNumber);

    if (client == null || room == null)
    {
        Console.WriteLine("Client or Room not found!");
        return;
    }

    Reservation res = new Reservation
    {
        Guest = client,
        ReservedRoom = room,
        Status = status,
        CheckInDate = checkIn,
        CheckOutDate = checkOut
    };

    db.Reservations.Add(res);
    db.SaveChanges();

    Console.WriteLine("Reservation added successfully!");
}

void GetAllReservations()
{
    var reservations = db.Reservations
        .Include(r => r.Guest)
        .Include(r => r.ReservedRoom)
        .ToList();

    if (!reservations.Any())
    {
        Console.WriteLine("No reservations found.");
        return;
    }

    foreach (var res in reservations)
    {
        Console.WriteLine(res);
    }
}

void GetReservationById()
{
    Console.Write("Reservation ID: ");
    int id = int.Parse(Console.ReadLine());

    var res = db.Reservations
        .Include(r => r.Guest)
        .Include(r => r.ReservedRoom)
        .FirstOrDefault(r => r.Id == id);

    if (res == null)
    {
        Console.WriteLine("Reservation not found.");
        return;
    }

    Console.WriteLine(res);
}

void UpdateReservation()
{
    Console.Write("Reservation ID: ");
    int id = int.Parse(Console.ReadLine());

    var res = db.Reservations
        .Include(r => r.Guest)
        .Include(r => r.ReservedRoom)
        .FirstOrDefault(r => r.Id == id);

    if (res == null)
    {
        Console.WriteLine("Reservation not found.");
        return;
    }

    Console.WriteLine($"Current Status: {res.Status}");
    Console.Write("New Status (leave empty to keep): ");
    string statusInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(statusInput))
        res.Status = Enum.Parse<Reservation.ReservationStatus>(statusInput);

    Console.WriteLine($"Current Check-in: {res.CheckInDate:yyyy-MM-dd}");
    Console.Write("New Check-in (yyyy-MM-dd, leave empty to keep): ");
    string checkInStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(checkInStr))
        res.CheckInDate = DateTime.Parse(checkInStr);

    Console.WriteLine($"Current Check-out: {res.CheckOutDate:yyyy-MM-dd}");
    Console.Write("New Check-out (yyyy-MM-dd, leave empty to keep): ");
    string checkOutStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(checkOutStr))
        res.CheckOutDate = DateTime.Parse(checkOutStr);

    db.SaveChanges();
    Console.WriteLine("Reservation updated successfully!");
}

void DeleteReservation()
{
    Console.Write("Reservation ID to delete: ");
    int id = int.Parse(Console.ReadLine());

    var res = db.Reservations.Find(id);
    if (res == null)
    {
        Console.WriteLine("Reservation not found.");
        return;
    }

    db.Reservations.Remove(res);
    db.SaveChanges();
    Console.WriteLine("Reservation deleted successfully!");
}


// -------------------- CRUD ROOMS --------------------

void ManageRooms()
{
    Console.WriteLine("\n--- MANAGE ROOMS ---");
    Console.WriteLine("1. Add a room");
    Console.WriteLine("2. Get all rooms");
    Console.WriteLine("3. Update room");
    Console.WriteLine("3. Update room");
    Console.WriteLine("4. Get room by number");
    Console.WriteLine("5. Delete room");
    Console.Write("\nYour choice : ");
    string choix = Console.ReadLine();
    switch (choix)
    {
        case "1":
            AddRoom();
            break;
        case "2":
            GetRooms();
            break;
        case "3":
            UpdateRoom();
            break;
        case "4":
            GetRoomByNumber();
            break;
        case "5":
            DeleteRoom();
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}

void AddRoom()
{

}
void GetRooms()
{
}
void UpdateRoom()
{
}
void GetRoomByNumber()
{
}
void DeleteRoom()
{
}

// -------------------- CRUD CLIENTS --------------------

void ManageClients()
{
    Console.WriteLine("\n--- MANAGE CLIENTS ---");
    Console.WriteLine("1. Add a client");
    Console.WriteLine("2. Get all clients");
    Console.WriteLine("3. Get client by id");
    Console.WriteLine("4. Update client");
    Console.WriteLine("5. Delete client");
    Console.Write("\nYour choice : ");

    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            AddClient();
            break;
        case "2":
            GetClients();
            break;
        case "3":
            UpdateClien();
            break;
        case "4":
            GetClientById();
            break;
        case "5":
            DeleteClient();
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}

void AddClient()
{
  
}

void GetClients()
{

}
void UpdateClien()
{

}
void GetClientById()
{

}
void DeleteClient()
{

}

