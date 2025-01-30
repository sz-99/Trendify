using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Backend.Models
{
    public class Colour
    {
        [Key]
        public int ColourId { get; set; }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public Colour(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b; 
            A = a;   
        }

        public static Colour FromColor(Color color)
        {
            var r = color.R;
            var g = color.G;    
            var b = color.B;
            var a = color.A;

            return new Colour(r, g, b, a);
        }

    }
}
