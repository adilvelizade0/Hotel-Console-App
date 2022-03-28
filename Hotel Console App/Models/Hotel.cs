using System;
using System.Collections;
using System.Linq;

namespace Hotel_Console_App.Models
{
    public class Hotel: IEnumerable
    {
        private static Room[] _rooms;

        private string Name { get; set; }
        private Room this[int index]
        {
            get => _rooms [index];
            set => _rooms [index] = value;
        }

        private Hotel()
        {
            _rooms = Array.Empty<Room>();
        }

        public Hotel(string name):this()
        {
            Name = name;
        }

        public void AddRoom(Room room)
        {
            Array.Resize(ref _rooms,_rooms.Length + 1);
            _rooms[^1] = room;
        }

        public static void RemoveRoom(int? id)
        {
            try
            {
                if (id is null)
                {
                    throw new NullReferenceException("\n❌  Id cannot be null!");
                }

                var room = Array.Find(_rooms, room => room.RoomId == id);
            
                if (room is null)
                {
                    throw new NullReferenceException("\n❌  No results found");
                }

                _rooms = _rooms.Length == 1 ? Array.Empty<Room>() : _rooms.Where(room => room.RoomId != id).ToArray();
                Console.WriteLine("\n✅ The book was successfully deleted!");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void MakeReservation(int? id)
        {
            try
            {
                if (id is null)
                {
                    throw new NullReferenceException("\n❌  Id cannot be null!");
                }

                Room room = Array.Find(_rooms, room => room.RoomId == id);
            
                if (room is null)
                {
                    throw new NullReferenceException("\n❌  No results found");
                }

                if (room.IsAvailable)
                {
                    room.IsAvailable = !room.IsAvailable;
                    Console.WriteLine("\n✅ The room was successfully reserved\n");
                }
                else
                {
                    throw new NotAvailableException("\n❌ The room is reserved");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void PrintAllRooms()
        {
            if (_rooms.Length == 0)
            {
                Console.WriteLine("\n❌ There is nothing yet\n");
            }
            
            foreach (var room in _rooms)
            {
                Console.WriteLine( $"\nName: {room.Name} 🏨\nPrice: {room.Price.ToString()} {(room.Price == 0 ? "free for 24 hours" : "")} 💰\nPerson Capacity: {room.PersonCapacity.ToString()} {(room.PersonCapacity == 0 ? "for stock 📦" : "for people 👥")}\nReserve: {(room.IsAvailable ? " ✅ " : " ❌ ")}\n");
            }
        }
        
        public IEnumerator GetEnumerator()
        {
            return _rooms.GetEnumerator();
        }
    }
}