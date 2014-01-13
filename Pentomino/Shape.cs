using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class Shape
    {
        public Shape(Piece piece, string orientation, bool[,] bitmap)
        {
            Piece = piece;
            Orientation = orientation;
            Bitmap = bitmap;
        }

        public Piece Piece { get; private set; } 
        public string Orientation { get; private set; } 
        public bool[,] Bitmap { get; private set; } 
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

        public static bool[,] FlipBitmapHorizontally(bool[,] original)
        {
            int width = original.GetLength(0);
            int height = original.GetLength(1);
            int x, y;
            bool[,] flipped = new bool[width, height];
            for (y = 0; y < height; ++y)
            {
                for (x = 0; x < width; ++x)
                {
                    flipped[x, y] = original[width - 1 - x, y];
                }
            }
            return flipped;
        }

        public static bool[,] FlipBitmapVertically(bool[,] original)
        {
            int width = original.GetLength(0);
            int height = original.GetLength(1);
            int x, y;
            bool[,] flipped = new bool[width, height];
            for (x = 0; x < width; ++x)
            {
                for (y = 0; y < height; ++y)
                {
                    flipped[x, y] = original[x, height - 1 - y];
                }
            }
            return flipped;
        }

        public static bool[,] RotateBitmapClockwise(bool[,] original)
        {
            int width = original.GetLength(0);
            int height = original.GetLength(1);
            int x, y;
            bool[,] rotated = new bool[height, width];
            for (x = 0; x < height; ++x)
            {
                for (y = 0; y < width; ++y)
                {
                    rotated[x, y] = original[width - 1 - y, x];
                }
            }
            return rotated;
        }
    }
}
