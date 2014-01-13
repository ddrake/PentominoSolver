using System;
using System.Collections.Generic;
using System.Text;


namespace Pentomino
{

    public abstract class Piece
    {
        public string Name { get; protected set; }
        public int Id { get; protected set; }
        public Shape[] Shapes { get; protected set; }

        public override bool Equals(object obj) { return Name == ((Piece)obj).Name; }
        public override int GetHashCode() { return Name.GetHashCode(); }
        public override string ToString() { return Name; }
    }

    public class Moose : Piece
    {
        public Moose()
        {
            Name = "Moose";
            Id = 1;
            Shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true }, { true, true }, { true, false }, { true, false } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[3].Bitmap);
            Shapes[4] = new Shape(this, "Head up, feet right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[4].Bitmap);
            Shapes[5] = new Shape(this, "Head up, feet left", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[5].Bitmap);
            Shapes[6] = new Shape(this, "Head down, feet left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[6].Bitmap);
            Shapes[7] = new Shape(this, "Head down, feet right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Bird : Piece
    {
        public Bird()
        {
            Name = "Bird";
            Id = 2;
            Shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true, true }, { true, true, false }, { false, true, false } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[3].Bitmap);
            Shapes[4] = new Shape(this, "Head up, feet right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[4].Bitmap);
            Shapes[5] = new Shape(this, "Head up, feet left", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[5].Bitmap);
            Shapes[6] = new Shape(this, "Head down, feet left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[6].Bitmap);
            Shapes[7] = new Shape(this, "Head down, feet right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Snail : Piece
    {
        public Snail()
        {
            Name = "Snail";
            Id = 3;
            Shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, false }, { true, true }, { true, true } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[3].Bitmap);
            Shapes[4] = new Shape(this, "Head up, belly right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[4].Bitmap);
            Shapes[5] = new Shape(this, "Head up, belly left", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[5].Bitmap);
            Shapes[6] = new Shape(this, "Head down, belly left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[6].Bitmap);
            Shapes[7] = new Shape(this, "Head down, belly right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Rabbit : Piece
    {
        public Rabbit()
        {
            Name = "Rabbit";
            Id = 4;
            Shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, true }, { true, false }, { true, false }, { true, false } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[3].Bitmap);
            Shapes[4] = new Shape(this, "Head up, belly right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[4].Bitmap);
            Shapes[5] = new Shape(this, "Head up, belly left", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[5].Bitmap);
            Shapes[6] = new Shape(this, "Head down, belly left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[6].Bitmap);
            Shapes[7] = new Shape(this, "Head down, belly right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Fish : Piece
    {
        public Fish()
        {
            Name = "Fish";
            Id = 5;
            Shapes = new Shape[8];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true }, { true, true }, { false, true }, { false, true } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Upside-down, facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Upside-down, facing left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[3].Bitmap);
            Shapes[4] = new Shape(this, "Head up, fin right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[4].Bitmap);
            Shapes[5] = new Shape(this, "Head up, fin left", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[5].Bitmap);
            Shapes[6] = new Shape(this, "Head down, fin left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[6].Bitmap);
            Shapes[7] = new Shape(this, "Head down, fin right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Whale : Piece
    {
        public Whale()
        {
            Name = "Whale";
            Id = 6;
            Shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, false, false }, { true, true, true }, { false, false, true } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Head down, tail right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Head down, tail left", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Ram : Piece
    {
        public Ram()
        {
            Name = "Ram";
            Id = 7;
            Shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, false, true }, { true, true, true }, { false, false, true } };
            Shapes[0] = new Shape(this, "Upright", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Upside-down", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Head left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Head right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Crab : Piece
    {
        public Crab()
        {
            Name = "Crab";
            Id = 8;
            Shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, true }, { true, false }, { true, true } };
            Shapes[0] = new Shape(this, "Claws up", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Claws down", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Claws left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Claws right", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Squirrel : Piece
    {
        public Squirrel()
        {
            Name = "Squirrel";
            Id = 9;
            Shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { true, false, false }, { true, false, false }, { true, true, true } };
            Shapes[0] = new Shape(this, "Facing left", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Facing right", bitmap);

            bitmap = Shape.FlipBitmapVertically(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Upside-down facing right", bitmap);

            bitmap = Shape.FlipBitmapHorizontally(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Upside-down facing left", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Bat : Piece
    {
        public Bat()
        {
            Name = "Bat";
            Id = 10;
            Shapes = new Shape[4];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, false, true }, { false, true, true }, { true, true, false } };
            Shapes[0] = new Shape(this, "Head top right", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "Head bottom right", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[1].Bitmap);
            Shapes[2] = new Shape(this, "Head bottom left", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[2].Bitmap);
            Shapes[3] = new Shape(this, "Head top left", bitmap);
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
            return Shapes[(int)orientation];
        }
    }

    public class Worm : Piece
    {
        public Worm()
        {
            Name = "Worm";
            Id = 11;
            Shapes = new Shape[2];
            bool[,] bitmap;

            bitmap = new bool[,] { { true }, { true }, { true }, { true }, { true } };
            Shapes[0] = new Shape(this, "horizontal", bitmap);

            bitmap = Shape.RotateBitmapClockwise(Shapes[0].Bitmap);
            Shapes[1] = new Shape(this, "vertical", bitmap);

        }
        public enum Orientation
        {
            Horizontal,
            Vertical
        }
        public Shape GetShape(Orientation orientation)
        {
            return Shapes[(int)orientation];
        }
    }

    public class Owl : Piece
    {
        public Owl()
        {
            Name = "Owl";
            Id = 12;
            Shapes = new Shape[1];
            bool[,] bitmap;

            bitmap = new bool[,] { { false, true, false }, { true, true, true }, { false, true, false }, };
            Shapes[0] = new Shape(this, "", bitmap);
        }
        public enum Orientation
        {
            Any
        }
        public Shape GetShape(Orientation orientation)
        {
            return Shapes[(int)orientation];
        }
    }

}
