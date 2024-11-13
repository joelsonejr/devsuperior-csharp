using Course.Entities.Enums;
using System;

namespace Course.Entities
{
    class Circle : Shape
    {
        public double Radius { get; set;}

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

    }
}