using Course.Entities.Enums;

namespace Course.Entities
{
    class Rectangles : Shape
    {   
        public double Width { get; set; }
        public double Height { get; set; }        

        
        public override double Area()
        {
            return Width * Height;
        }
    }
}