using Hotel.Data;
using Hotel.Models;
using Hotel.Repository;

AppDbContext db = new AppDbContext();
ReservationRepository reservationRepo = new ReservationRepository(db);
ClientRepository clientRepository = new ClientRepository(db);
RoomRepository roomRepository = new RoomRepository(db);

bool continuer = true;

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

// -------------------- RESERVATIONS --------------------

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

    var client = clientRepository.GetById(clientId);
    var room = roomRepository.GetById(roomNumber);

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

    reservationRepo.Add(res);
    Console.WriteLine("Reservation added successfully!");
}

void GetAllReservations()
{
    var reservations = reservationRepo.GetAll();

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

    var res = reservationRepo.GetById(id);

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

    var res = reservationRepo.GetById(id);

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

    reservationRepo.Update(id, res);
    Console.WriteLine("Reservation updated successfully!");
}

void DeleteReservation()
{
    Console.Write("Reservation ID to delete: ");
    int id = int.Parse(Console.ReadLine());

    bool success = reservationRepo.Delete(id);

    if (success)
        Console.WriteLine("Reservation deleted successfully!");
    else
        Console.WriteLine("Reservation not found.");
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

