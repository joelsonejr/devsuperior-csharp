using Course.Entities.Enums;

namespace Course.Entities
{
    abstract class Shape
    {
        public Colors Color { get; set;}

        public Shape(Colors color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}