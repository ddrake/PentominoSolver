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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 1), new Location(1, 0), new Location(1, 1), new Location(2, 0), new Location(3, 0) };
            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Upside-down, facing right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Upside-down, facing left", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Head up, feet right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Head up, feet left", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Head down, feet left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Head down, feet right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 1), new Location(0, 2), new Location(1, 0), new Location(1, 1), new Location(2, 1) };

            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Upside-down, facing right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Upside-down, facing left", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Head up, feet right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Head up, feet left", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Head down, feet left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Head down, feet right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 0), new Location(1, 0), new Location(1, 1), new Location(2, 0), new Location(2, 1) };
            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Upside-down, facing right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Upside-down, facing left", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Head up, belly right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Head up, belly left", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Head down, belly left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Head down, belly right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 0), new Location(0, 1), new Location(1, 0), new Location(2, 0), new Location(3, 0) };

            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Upside-down, facing right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Upside-down, facing left", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Head up, belly right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Head up, belly left", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Head down, belly left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Head down, belly right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 1), new Location(1, 0), new Location(1, 1), new Location(2, 1), new Location(3, 1) };
            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Upside-down, facing right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Upside-down, facing left", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Head up, fin right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Head up, fin left", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Head down, fin left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Head down, fin right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 0), new Location(1, 0), new Location(1, 1), new Location(1, 2), new Location(2, 2) };
            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Head down, tail right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Head down, tail left", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 2), new Location(1, 0), new Location(1, 1), new Location(1, 2), new Location(2, 2) };
            Shapes[0] = new Shape(this, "Upright", closed);

            closed = Shape.FlipBitmapVertically(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Upside-down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Head left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Head right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 0), new Location(0, 1), new Location(1, 0), new Location(2, 0), new Location(2, 1) };
            Shapes[0] = new Shape(this, "Claws up", closed);

            closed = Shape.FlipBitmapVertically(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Claws down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Claws left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Claws right", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 0), new Location(1, 0), new Location(2, 0), new Location(2, 1), new Location(2, 2) };
            Shapes[0] = new Shape(this, "Facing left", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing right", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Upside-down facing right", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Upside-down facing left", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 2), new Location(1, 1), new Location(1, 2), new Location(2,0), new Location(2, 1) };
            Shapes[0] = new Shape(this, "Head top right", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Head bottom right", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Head bottom left", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Head top left", closed);
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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 0), new Location(1, 0), new Location(2, 0), new Location(3, 0), new Location(4, 0) };
            Shapes[0] = new Shape(this, "horizontal", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "vertical", closed);

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
            HashSet<Location> closed;

            closed = new HashSet<Location>() { new Location(0, 1), new Location(1, 0), new Location(1, 1), new Location(1, 2), new Location(2, 1) };
            Shapes[0] = new Shape(this, "", closed);
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
