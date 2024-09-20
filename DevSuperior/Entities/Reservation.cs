using Course.Entities.Exceptions;

namespace Course.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() {}

        public Reservation (int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
                {
                    throw new DomainException ("Error in reservation: check-out date must be after check in date ");
                }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration ()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);

            return (int)duration.TotalDays;
        }

        //Excessões Personalizadas, pt 3.
        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {   
        DateTime now = DateTime.Now;

            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }

            if (checkOut <= checkIn)
            {
                throw new DomainException ("check-out date must be after check in date ");
            }
            
            CheckIn = checkIn;
            CheckOut = checkOut;

        }

        // //Excessões Personalizadas, pt 2.
        // public string UpdateDates(DateTime checkIn, DateTime checkOut)
        // {   
        // DateTime now = DateTime.Now;

        //     if (checkIn < now || checkOut < now)
        //     {
        //         return "Reservation dates for update must be future dates";
        //     }

        //     if (checkOut <= checkIn)
        //     {
        //         return "check-out date must be after check in date ";
        //     }
            
        //     CheckIn = checkIn;
        //     CheckOut = checkOut;

        //     return null;
        // }
        // //Excessões Personalizadas, pt 2.
        // public string UpdateDates(DateTime checkIn, DateTime checkOut)
        // {   
        // DateTime now = DateTime.Now;

        //     if (checkIn < now || checkOut < now)
        //     {
        //         return "Error in reservation: Reservation dates for update must be future dates";
        //     }

        //     if (checkOut <= checkIn)
        //     {
        //         return "Error in reservation: check-out date must be after check in date ";
        //     }
            
        //     CheckIn = checkIn;
        //     CheckOut = checkOut;

        //     return null;
        // }

        override public string ToString ()
        {
            return "Room "
                + RoomNumber
                + ", check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", "
                + Duration()
                + " nights";
        }
    }
}