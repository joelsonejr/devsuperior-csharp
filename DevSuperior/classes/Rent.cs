using System;

namespace Course {
    class Guest {
        public string? Name {get; set;}
        public string? Email {get; set;}
        public int RoomNumber {get; set;}

        public Guest () {

        }

        public Guest (string name, string email, int roomNumber) {
            Name = name;
            Email = email;
            RoomNumber = roomNumber;
        }

        public override string ToString()
        {
            return RoomNumber + ": " + Name + ", " + Email;
        }

    }
}