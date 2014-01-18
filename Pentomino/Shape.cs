using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class Shape
    {
        public Shape(Piece piece, string orientation, HashSet<Location> bitmap)
        {
            Piece = piece;
            Orientation = orientation;
            Bitmap = bitmap;
        }

        public Piece Piece { get; private set; } 
        public string Orientation { get; private set; } 
        public HashSet<Location> Bitmap { get; private set; } 
        public override bool Equals(object obj)
        {
            Shape shape = (Shape)obj;
            return Piece == shape.Piece && Orientation == shape.Orientation;
        }
        public override int GetHashCode()
        {
            return Piece.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Piece, Orientation);
        }

        public static HashSet<Location> FlipBitmapHorizontally(HashSet<Location> original)
        {
            int maxX = original.Max(loc => loc.x);
            var results = original.Select<Location, Location>(loc => new Location(maxX - loc.x, loc.y));
            return new HashSet<Location>(results);
        }

        public static HashSet<Location> FlipBitmapVertically(HashSet<Location> original)
        {
            int maxY = original.Max(loc => loc.y);
            var results = original.Select<Location, Location>(loc => new Location(loc.x, maxY - loc.y));
            return new HashSet<Location>(results);
        }

        public static HashSet<Location> RotateBitmapClockwise(HashSet<Location> original)
        {
            int maxX = original.Max(loc => loc.x);
            var results = original.Select<Location, Location>(loc => new Location(loc.y, maxX - loc.x));
            return new HashSet<Location>(results);
        }
    }
}
