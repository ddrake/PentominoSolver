using System;
using System.Collections.Generic;
using System.Text;


namespace Pentomino
{
    public class Placement
    {
        private Shape shape;
        private Location location;

        public Placement(Shape shape, Location location)
        {
            this.shape = shape;
            this.location = location;
        }
        public Placement(Enum orientation, int x, int y)
        {
            this.shape = GetShape(orientation);
            this.location = new Location(x,y);
        }

        private Shape GetShape(Enum orientation)
        {
            Type type = orientation.GetType();

            if (type == typeof(Moose.Orientation))
            {
                return new Moose().GetShape((Moose.Orientation)orientation);
            }
            else if (type == typeof(Squirrel.Orientation))
            {
                return new Squirrel().GetShape((Squirrel.Orientation)orientation);
            }
            else if (type == typeof(Bat.Orientation))
            {
                return new Bat().GetShape((Bat.Orientation)orientation);
            }
            else if (type == typeof(Rabbit.Orientation))
            {
                return new Rabbit().GetShape((Rabbit.Orientation)orientation);
            }
            else if (type == typeof(Worm.Orientation))
            {
                return new Worm().GetShape((Worm.Orientation)orientation);
            }
            else if (type == typeof(Whale.Orientation))
            {
                return new Whale().GetShape((Whale.Orientation)orientation);
            }
            else if (type == typeof(Fish.Orientation))
            {
                return new Fish().GetShape((Fish.Orientation)orientation);
            }
            else if (type == typeof(Bird.Orientation))
            {
                return new Bird().GetShape((Bird.Orientation)orientation);
            }
            else if (type == typeof(Crab.Orientation))
            {
                return new Crab().GetShape((Crab.Orientation)orientation);
            }
            else if (type == typeof(Snail.Orientation))
            {
                return new Snail().GetShape((Snail.Orientation)orientation);
            }
            else if (type == typeof(Owl.Orientation))
            {
                return new Owl().GetShape((Owl.Orientation)orientation);
            }
            else if (type == typeof(Ram.Orientation))
            {
                return new Ram().GetShape((Ram.Orientation)orientation);
            }
            else
            {
                throw new ArgumentException("Invalid orientation");
            }
        }
        public override string ToString()
        {
            return String.Format("{0} at {1}", this.shape, this.location);
        }
        public bool[,] UpdateBitmap(bool[,] bitmap, bool isAdding)
        {
            bool[,] pieceMap = shape.Bitmap;
            int width = pieceMap.GetLength(0); 
            int height = pieceMap.GetLength(1);
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (pieceMap[x, y]) bitmap[location.x + x, location.y + y] = isAdding;
                }
            }
            return bitmap;
        }
        public void RemovePieceFromList(ref List<Piece> pieces)
        {
            pieces.Remove(shape.Piece);
        }
        public void AddPieceToList(ref List<Piece> pieces)
        {
            pieces.Add(shape.Piece);
        }
    }
    public class Shape
    {
        public Shape(Piece piece, string orientation, bool[,] bitmap)
        {
            this.piece = piece;
            this.orientation = orientation;
            this.bitmap = bitmap;
        }

        private Piece piece;
        private string orientation;
        private bool[,] bitmap;

        public Piece Piece { get { return piece; } }
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
                    rotated[x, y] = original[width-1-y, x];
                }
            }
            return rotated;
        }
    }

    public abstract class Piece
    {
        protected string name;
        protected Shape[] shapes;
        protected int id;

        public Shape[] Shapes { get { return shapes; } }

        public string Name { get { return name; } }

        public int Id { get { return id; } }
        
        public override bool Equals(object obj)
        {
            return this.name == ((Piece)obj).Name;
        }
        public override string ToString()
        {
            return this.name;
        }
    }

    public class Moose : Piece
    {
        public Moose()
        {
            this.name = "Moose";
            this.id = 1;
            this.shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true }, { true, true }, { true, false }, { true, false } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[3].Bitmap);
            shapes[4] = new Shape(this, "Head up, feet right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[4].Bitmap);
            shapes[5] = new Shape(this, "Head up, feet left", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[5].Bitmap);
            shapes[6] = new Shape(this, "Head down, feet left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[6].Bitmap);
            shapes[7] = new Shape(this, "Head down, feet right", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            UpsideDownFacingRight, 
            UpsideDownFacingLeft,
            HeadUpFeetRight,
            HeadUpFeetLeft,
            HeadDownFeetLeft,
            HeadDownFeetRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Bird : Piece
    {
        public Bird()
        {
            this.name = "Bird";
            this.id = 2;
            this.shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true, true }, { true, true, false }, { false, true, false } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[3].Bitmap);
            shapes[4] = new Shape(this, "Head up, feet right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[4].Bitmap);
            shapes[5] = new Shape(this, "Head up, feet left", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[5].Bitmap);
            shapes[6] = new Shape(this, "Head down, feet left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[6].Bitmap);
            shapes[7] = new Shape(this, "Head down, feet right", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            UpsideDownFacingRight,
            UpsideDownFacingLeft,
            HeadUpFeetRight,
            HeadUpFeetLeft,
            HeadDownFeetLeft,
            HeadDownFeetRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Snail : Piece
    {
        public Snail()
        {
            this.name = "Snail";
            this.id = 3;
            this.shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, false }, { true, true }, { true, true } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[3].Bitmap);
            shapes[4] = new Shape(this, "Head up, belly right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[4].Bitmap);
            shapes[5] = new Shape(this, "Head up, belly left", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[5].Bitmap);
            shapes[6] = new Shape(this, "Head down, belly left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[6].Bitmap);
            shapes[7] = new Shape(this, "Head down, belly right", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            UpsideDownFacingRight,
            UpsideDownFacingLeft,
            HeadUpBellyRight,
            HeadUpBellyLeft,
            HeadDownBellyLeft,
            HeadDownBellyRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Rabbit : Piece
    {
        public Rabbit()
        {
            this.name = "Rabbit";
            this.id = 4;
            this.shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, true }, { true, false }, { true, false }, { true, false } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[3].Bitmap);
            shapes[4] = new Shape(this, "Head up, belly right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[4].Bitmap);
            shapes[5] = new Shape(this, "Head up, belly left", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[5].Bitmap);
            shapes[6] = new Shape(this, "Head down, belly left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[6].Bitmap);
            shapes[7] = new Shape(this, "Head down, belly right", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            UpsideDownFacingRight,
            UpsideDownFacingLeft,
            HeadUpBellyRight,
            HeadUpBellyLeft,
            HeadDownBellyLeft,
            HeadDownBellyRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Fish : Piece
    {
        public Fish()
        {
            this.name = "Fish";
            this.id = 5;
            this.shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true }, { true, true }, { false, true }, { false, true } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[3].Bitmap);
            shapes[4] = new Shape(this, "Head up, fin right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[4].Bitmap);
            shapes[5] = new Shape(this, "Head up, fin left", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[5].Bitmap);
            shapes[6] = new Shape(this, "Head down, fin left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[6].Bitmap);
            shapes[7] = new Shape(this, "Head down, fin right", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            UpsideDownFacingRight,
            UpsideDownFacingLeft,
            HeadUpFinRight,
            HeadUpFinLeft,
            HeadDownFinLeft,
            HeadDownFinRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Whale : Piece
    {
        public Whale()
        {
            this.name = "Whale";
            this.id = 6;
            this.shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, false, false }, { true, true, true }, { false, false, true } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Head down, tail right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Head down, tail left", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            HeadDownTailLeft,
            HeadDownTailRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Ram : Piece
    {
        public Ram()
        {
            this.name = "Ram";
            this.id = 7;
            this.shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, false, true }, { true, true, true }, { false, false, true } };
            shapes[0] = new Shape(this, "Upright", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Upside-down", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Head left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Head right", bitmap);
        }
        public enum Orientation
        {
            Upright,
            UpsideDown,
            HeadLeft,
            HeadRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Crab : Piece
    {
        public Crab()
        {
            this.name = "Crab";
            this.id = 8;
            this.shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, true }, { true, false }, { true, true } };
            shapes[0] = new Shape(this, "Claws up", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Claws down", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Claws left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Claws right", bitmap);
        }
        public enum Orientation
        {
            ClawsUp,
            ClawsDown,
            ClawsLeft,
            ClawsRight
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Squirrel : Piece
    {
        public Squirrel()
        {
            this.name = "Squirrel";
            this.id = 9;
            this.shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, false, false }, { true, false, false }, { true, true, true } };
            shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Upside-down facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Upside-down facing left", bitmap);
        }
        public enum Orientation
        {
            FacingLeft,
            FacingRight,
            UpsideDownFacingRight,
            UpsideDownFacingLeft
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Bat : Piece
    {
        public Bat()
        {
            this.name = "Bat";
            this.id = 10;
            this.shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, false, true }, { false, true, true }, { true, true, false } };
            shapes[0] = new Shape(this, "Head top right", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "Head bottom right", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[1].Bitmap);
            shapes[2] = new Shape(this, "Head bottom left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[2].Bitmap);
            shapes[3] = new Shape(this, "Head top left", bitmap);
        }
        public enum Orientation
        {
            HeadTopRight,
            HeadBottomRight,
            HeadBottomLeft,
            HeadTopLeft
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Worm : Piece
    {
        public Worm()
        {
            this.name = "Worm";
            this.id = 11;
            this.shapes = new Shape[2];
            bool[,] bitmap;

            bitmap = new bool[,] { { true }, { true }, { true }, { true }, { true } };
            shapes[0] = new Shape(this, "horizontal", bitmap);

            bitmap = Shape.RotateBitmapClockwise(shapes[0].Bitmap);
            shapes[1] = new Shape(this, "vertical", bitmap);

        }
        public enum Orientation
        {
            Horizontal,
            Vertical
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
        }
    }

    public class Owl : Piece
    {
        public Owl()
        {
            this.name = "Owl";
            this.id = 12;
            this.shapes = new Shape[1];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false }, };
            shapes[0] = new Shape(this, "", bitmap);
        }
        public enum Orientation
        {
            Any
        }
        public Shape GetShape(Orientation orientation)
        {
            return shapes[(int)orientation];
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


}
