using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Console.Write("Quantos quartos serão necessários (1 a 10): ");
            int amountRooms = int.Parse(Console.ReadLine());

            Boolean registration = false;

            while (!registration) {
                if (amountRooms < 1 || amountRooms > 10) {
                    Console.Write("How many rooms will be rented? ");
                    amountRooms = int.Parse(Console.ReadLine());
                }
                else {
                    registration = true;
                }
            }

            Guest[] hotelRooms = new Guest[10];

            for (int i = 0; i < amountRooms; i++) {
                 
                Guest g = new Guest();

                Console.WriteLine();
                Console.WriteLine($"Rent #{i+1}");
                Console.Write("Name: ");
                g.Name = Console.ReadLine();
                Console.Write("E-mail: ");
                g.Email = Console.ReadLine();
                Console.Write("Select your room (from 0 to 9): ");
                g.RoomNumber = int.Parse(Console.ReadLine());

                hotelRooms[g.RoomNumber] = g;

            }

            Console.WriteLine();
            Console.WriteLine("Busy rooms:");

            for (int i = 0; i < hotelRooms.Length; i++) {

                if( hotelRooms[i] != null ) {

                    Console.WriteLine(hotelRooms[i]);
                }
            }


        }
    }
}