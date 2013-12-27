using System;
using System.Collections.Generic;


namespace Pentomino
{
    public interface IPiece
    {
        string Name();

        Shape[] Shapes();
    }

    public class Moose : IPiece
    {
        private Shape[] shapes;
        public Shape[] Shapes()
        {
            return shapes;
        }

        private string name;
        public string Name() 
        { 
            return name; 
        } 
      
        public Moose()
        {
            this.name = "Moose";
            this.shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true, true, true }, { true, true, false, false } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = new bool[,] { { true, true, true, false }, { false, false, true, true } };
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = new bool[,] { { true, true, true, false }, { false, false, true, true } };
            shapes[2] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = new bool[,] { { true, true, true, false }, { false, false, true, true } };
            shapes[3] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = new bool[,] { { false, true }, { true, true }, { true, false}, {true, false} };
            shapes[4] = new Shape(this, "Head down, feet left", bitmap);

            bitmap = new bool[,] { { true, false }, { true, true }, { false, true }, { false, true } };
            shapes[5] = new Shape(this, "Head down, feet right", bitmap);

            bitmap = new bool[,] { { true, false }, { true, false }, { true, true }, { false, true } };
            shapes[6] = new Shape(this, "Head up, feet left", bitmap);

            bitmap = new bool[,] { { false, true }, { false, true }, { true, true }, { true, false } };
            shapes[7] = new Shape(this, "Head up, feet right", bitmap);
        }
        public override bool Equals(object obj)
        {
            return this.name == ((Moose)obj).Name();
        }
        public override string ToString()
        {
            return this.name;
        }
    }
	
    public class Shape
    {
        public Shape(IPiece piece, string orientation, bool[,] bitmap)
        {
            this.piece = piece;
            this.orientation = orientation;
            this.bitmap = bitmap;
        }

        private IPiece piece;
        private string orientation;
        private bool[,] bitmap;

        public IPiece Piece { get { return piece; } }
        public string Orientation { get { return orientation; } }
        public bool[,] Bitmap { get { return bitmap; } }
        public override bool Equals(object obj)
        {
            Shape shape = (Shape)obj;
            return this.piece == shape.Piece && this.orientation == shape.Orientation;
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}", this.piece, this.orientation);
        }
    }

    public struct Location
    {

        public int x, y;
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return String.Format("({0},{1})", x, y);
        }
    }

    public class Placement
    {
        private Shape shape;
        private Location location;

        public Placement(Shape shape, Location location)
        {
            this.shape = shape;
            this.location = location;
        }
        public override string ToString()
        {
            return String.Format("{0} at {1}", this.shape, this.location);
        }
    }

}
