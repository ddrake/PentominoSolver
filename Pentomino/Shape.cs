using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class Shape
    {
        public Shape(Piece piece, string orientation, HashSet<Pt> closed)
        {
            Piece = piece;
            Orientation = orientation;
            Closed = closed;
        }

        public Piece Piece { get; private set; } 
        public string Orientation { get; private set; } 
        public HashSet<Pt> Closed { get; private set; } 
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

        public static HashSet<Pt> FlipBitmapHorizontally(HashSet<Pt> original)
        {
            int maxX = original.Max(loc => loc.x);
            int maxZ = original.Max(loc => loc.z);
            var results = original.Select<Pt, Pt>(loc => new Pt(maxX - loc.x, loc.y, maxZ - loc.z));
            return new HashSet<Pt>(results);
        }

        public static HashSet<Pt> FlipBitmapVertically(HashSet<Pt> original)
        {
            int maxY = original.Max(loc => loc.y);
            int maxZ = original.Max(loc => loc.z);
            var results = original.Select<Pt, Pt>(loc => new Pt(loc.x, maxY - loc.y, maxZ - loc.z));
            return new HashSet<Pt>(results);
        }

        public static HashSet<Pt> RotateBitmapClockwise(HashSet<Pt> original)
        {
            int maxX = original.Max(loc => loc.x);
            var results = original.Select<Pt, Pt>(loc => new Pt(loc.y, maxX - loc.x, loc.z));
            return new HashSet<Pt>(results);
        }

        public static HashSet<Pt> RotateBitmapToward(HashSet<Pt> original)
        {
            int maxZ = original.Max(loc => loc.z);
            var results = original.Select<Pt, Pt>(loc => new Pt(loc.x, maxZ - loc.z, loc.y));
            return new HashSet<Pt>(results);
        }

        public static HashSet<Pt> RotateBitmapAway(HashSet<Pt> original)
        {
            int maxY = original.Max(loc => loc.y);
            var results = original.Select<Pt, Pt>(loc => new Pt(loc.x, loc.z, maxY - loc.y));
            return new HashSet<Pt>(results);
        }
    }
}
