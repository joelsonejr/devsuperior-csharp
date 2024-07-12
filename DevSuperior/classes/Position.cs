using System;

namespace Course {
    public class Position {
        public int XPos {get; set;}
        public int YPos {get; set;}
        public int? LeftNeighbour {get; set;}
        public int? RightNeighbour {get; set;}
        public int? UpNeighbour {get; set;}
        public int? DownNeighbour {get; set;}

        public int Value {get; set;}

        public Position() {

        }
    }
}