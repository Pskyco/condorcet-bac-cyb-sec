using Polymorphisme.Classes.Abstract;

namespace Polymorphisme.Classes
{
    public class Rectangle : GeometricShape
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }

        public override decimal GetArea()
        {
            // A = L x l
            return Length * Width;
        }

        public override decimal GetPerimeter()
        {
            // P = 2 x (L + l)
            return 2 * (Length + Width);
        }
    }
}