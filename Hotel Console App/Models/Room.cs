namespace Hotel_Console_App.Models
{
    public class Room
    {
        private static int _roomId;
        private int _price;
        private int _personCapacity;

        public string Name { get; set; }

        public int Price
        {
            get => _price;
            set => _price = value < 0 ? 0 : value;
        }

        public int PersonCapacity
        {
            get => _personCapacity;
            set => _personCapacity = value < 0 ? 0 : value;
        }

        public int RoomId
        {
            get;
            set;
        }

        public bool IsAvailable { get; set; }

        static Room()
        {
            _roomId = 0;
        }
        
        private Room()
        {
            IsAvailable = true;
        }
        
        public Room(string name, int price, int personCapacity):this()
        {
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
            
            RoomId = ++_roomId;
        }

        public Room(string name, int price, int personCapacity, bool isAvailable):this(name,price,personCapacity)
        {
            IsAvailable = isAvailable;
        }

        private string ShowInfo()
        {
            return $"\nName: {Name} 🏨\nPrice: {Price.ToString()} 💰\nPerson Capacity: {PersonCapacity.ToString()} 👥\nReserve: {(IsAvailable ? " ✅ " : " ❌ ")}\n";
        }

        public override string ToString()
        {
            return ShowInfo();
        }
    }
}