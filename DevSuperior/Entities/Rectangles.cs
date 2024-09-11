using Course.Entities.Enums;

namespace Course.Entities
{
    class Rectangles : Shape
    {   
        public double Width { get; set; }
        public double Height { get; set; }        

        public Rectangles (double width, double height, Colors color) : base(color)
        {
            Width = width;
            Height = height;

        }
        
        public override double Area()
        {
            return Width * Height;
        }
    }
}