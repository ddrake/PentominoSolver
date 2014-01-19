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
            Shapes = new Shape[24];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(1, 0), new Pt(1, 1), new Pt(2, 0), new Pt(3, 0) };
            Shapes[0] = new Shape(this, "Feet South, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Feet South, facing East", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Feet North, facing East", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Feet North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Feet East, facing North", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Feet West, facing North", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Feet West, facing South", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Feet East, facing South", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[8] = new Shape(this, "Feet down, facing West", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[9] = new Shape(this, "Feet up, facing West", closed);

            closed = Shape.RotateBitmapToward(Shapes[4].Closed);
            Shapes[10] = new Shape(this, "Feet East, facing up", closed);

            closed = Shape.RotateBitmapAway(Shapes[4].Closed);
            Shapes[11] = new Shape(this, "Feet East, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[12] = new Shape(this, "Feet down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[12].Closed);
            Shapes[13] = new Shape(this, "Feet down, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[13].Closed);
            Shapes[14] = new Shape(this, "Feet down, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[15] = new Shape(this, "Feet up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[15].Closed);
            Shapes[16] = new Shape(this, "Feet up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[16].Closed);
            Shapes[17] = new Shape(this, "Feet up, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[18] = new Shape(this, "Feet South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[18].Closed);
            Shapes[19] = new Shape(this, "Feet West, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[19].Closed);
            Shapes[20] = new Shape(this, "Feet North, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[11].Closed);
            Shapes[21] = new Shape(this, "Feet South, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[21].Closed);
            Shapes[22] = new Shape(this, "Feet West, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[22].Closed);
            Shapes[23] = new Shape(this, "Feet North, facing down", closed);


        }
        public enum Orientation
        {
            FeetSouthFacingWest,
            FeetSouthFacingEast,
            FeetNorthFacingEast,
            FeetNorthFacingWest,
            FeetEastFacingNorth,
            FeetWestFacingNorth,
            FeetWestFacingSouth,
            FeetEastFacingSouth,
            FeetDownFacingWest,
            FeetUpFacingWest,
            FeetEastFacingUp,
            FeetEastFacingDown,
            FeetDownFacingNorth,
            FeetDownFacingEast,
            FeetDownFacingSouth,
            FeetUpFacingNorth,
            FeetUpFacingEast,
            FeetUpFacingSouth,
            FeetSouthFacingUp,
            FeetWestFacingUp,
            FeetNorthFacingUp,
            FeetSouthFacingDown,
            FeetWestFacingDown,
            FeetNorthFacingDown
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
            Shapes = new Shape[24];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(0, 2), new Pt(1, 0), new Pt(1, 1), new Pt(2, 1) };

            Shapes[0] = new Shape(this, "Feet South, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Feet South, facing East", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Feet North, facing East", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Feet North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Feet East, facing North", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Feet West, facing North", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Feet West, facing South", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Feet East, facing South", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[8] = new Shape(this, "Feet down, Facing West", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[9] = new Shape(this, "Feet up, Facing West", closed);

            closed = Shape.RotateBitmapToward(Shapes[4].Closed);
            Shapes[10] = new Shape(this, "Feet East, facing up", closed);

            closed = Shape.RotateBitmapAway(Shapes[4].Closed);
            Shapes[11] = new Shape(this, "Feet East, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[12] = new Shape(this, "Feet down, Facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[12].Closed);
            Shapes[13] = new Shape(this, "Feet down, Facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[13].Closed);
            Shapes[14] = new Shape(this, "Feet down, Facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[15] = new Shape(this, "Feet up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[15].Closed);
            Shapes[16] = new Shape(this, "Feet up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[16].Closed);
            Shapes[17] = new Shape(this, "Feet up, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[18] = new Shape(this, "Feet South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[18].Closed);
            Shapes[19] = new Shape(this, "Feet West, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[19].Closed);
            Shapes[20] = new Shape(this, "Feet North, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[11].Closed);
            Shapes[21] = new Shape(this, "Feet South, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[21].Closed);
            Shapes[22] = new Shape(this, "Feet West, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[22].Closed);
            Shapes[23] = new Shape(this, "Feet North, facing down", closed);
        }
        public enum Orientation
        {
            FeetSouthFacingWest,
            FeetSouthFacingEast,
            FeetNorthFacingEast,
            FeetNorthFacingWest,
            FeetEastFacingNorth,
            FeetWestFacingNorth,
            FeetWestFacingSouth,
            FeetEastFacingSouth,
            FeetDownFacingWest,
            FeetUpFacingWest,
            FeetEastFacingUp,
            FeetEastFacingDown,
            FeetDownFacingNorth,
            FeetDownFacingEast,
            FeetDownFacingSouth,
            FeetUpFacingNorth,
            FeetUpFacingEast,
            FeetUpFacingSouth,
            FeetSouthFacingUp,
            FeetWestFacingUp,
            FeetNorthFacingUp,
            FeetSouthFacingDown,
            FeetWestFacingDown,
            FeetNorthFacingDown
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
            Shapes = new Shape[24];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 0), new Pt(1, 0), new Pt(1, 1), new Pt(2, 0), new Pt(2, 1) };
            Shapes[0] = new Shape(this, "Belly South, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Belly South, facing East", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Belly North, facing East", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Belly North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Belly East, facing North", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Belly West, facing North", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Belly West, facing South", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Belly East, facing South", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[8] = new Shape(this, "Belly down, facing West", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[9] = new Shape(this, "Belly up, facing West", closed);

            closed = Shape.RotateBitmapToward(Shapes[4].Closed);
            Shapes[10] = new Shape(this, "Belly East, facing up", closed);

            closed = Shape.RotateBitmapAway(Shapes[4].Closed);
            Shapes[11] = new Shape(this, "Belly East, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[12] = new Shape(this, "Belly down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[12].Closed);
            Shapes[13] = new Shape(this, "Belly down, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[13].Closed);
            Shapes[14] = new Shape(this, "Belly down, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[15] = new Shape(this, "Belly up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[15].Closed);
            Shapes[16] = new Shape(this, "Belly up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[16].Closed);
            Shapes[17] = new Shape(this, "Belly up, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[18] = new Shape(this, "Belly South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[18].Closed);
            Shapes[19] = new Shape(this, "Belly West, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[19].Closed);
            Shapes[20] = new Shape(this, "Belly North, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[11].Closed);
            Shapes[21] = new Shape(this, "Belly South, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[21].Closed);
            Shapes[22] = new Shape(this, "Belly West, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[22].Closed);
            Shapes[23] = new Shape(this, "Belly North, facing down", closed);

        }
        public enum Orientation
        {
            BellySouthFacingWest,
            BellySouthFacingEast,
            BellyNorthFacingEast,
            BellyNorthFacingWest,
            BellyEastFacingNorth,
            BellyWestFacingNorth,
            BellyWestFacingSouth,
            BellyEastFacingSouth,
            BellyDownFacingWest,
            BellyUpFacingWest,
            BellyEastFacingUp,
            BellyEastFacingDown,
            BellyDownFacingNorth,
            BellyDownFacingEast,
            BellyDownFacingSouth,
            BellyUpFacingNorth,
            BellyUpFacingEast,
            BellyUpFacingSouth,
            BellySouthFacingUp,
            BellyWestFacingUp,
            BellyNorthFacingUp,
            BellySouthFacingDown,
            BellyWestFacingDown,
            BellyNorthFacingDown
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
            Shapes = new Shape[24];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 0), new Pt(0, 1), new Pt(1, 0), new Pt(2, 0), new Pt(3, 0) };

            Shapes[0] = new Shape(this, "Belly South, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Belly South, facing East", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Belly North, facing East", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Belly North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Belly East, facing North", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Belly West, facing North", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Belly West, facing South", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Belly East, facing South", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[8] = new Shape(this, "Belly down, facing West", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[9] = new Shape(this, "Belly up, facing West", closed);

            closed = Shape.RotateBitmapToward(Shapes[4].Closed);
            Shapes[10] = new Shape(this, "Belly East, facing up", closed);

            closed = Shape.RotateBitmapAway(Shapes[4].Closed);
            Shapes[11] = new Shape(this, "Belly East, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[12] = new Shape(this, "Belly down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[12].Closed);
            Shapes[13] = new Shape(this, "Belly down, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[13].Closed);
            Shapes[14] = new Shape(this, "Belly down, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[15] = new Shape(this, "Belly up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[15].Closed);
            Shapes[16] = new Shape(this, "Belly up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[16].Closed);
            Shapes[17] = new Shape(this, "Belly up, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[18] = new Shape(this, "Belly South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[18].Closed);
            Shapes[19] = new Shape(this, "Belly West, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[19].Closed);
            Shapes[20] = new Shape(this, "Belly North, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[11].Closed);
            Shapes[21] = new Shape(this, "Belly South, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[21].Closed);
            Shapes[22] = new Shape(this, "Belly West, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[22].Closed);
            Shapes[23] = new Shape(this, "Belly North, facing down", closed);
        }
        public enum Orientation
        {
            BellySouthFacingWest,
            BellySouthFacingEast,
            BellyNorthFacingEast,
            BellyNorthFacingWest,
            BellyEastFacingNorth,
            BellyWestFacingNorth,
            BellyWestFacingSouth,
            BellyEastFacingSouth,
            BellyDownFacingWest,
            BellyUpFacingWest,
            BellyEastFacingUp,
            BellyEastFacingDown,
            BellyDownFacingNorth,
            BellyDownFacingEast,
            BellyDownFacingSouth,
            BellyUpFacingNorth,
            BellyUpFacingEast,
            BellyUpFacingSouth,
            BellySouthFacingUp,
            BellyWestFacingUp,
            BellyNorthFacingUp,
            BellySouthFacingDown,
            BellyWestFacingDown,
            BellyNorthFacingDown,
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
            Shapes = new Shape[24];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(1, 0), new Pt(1, 1), new Pt(2, 1), new Pt(3, 1) };
            Shapes[0] = new Shape(this, "Fin South, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Fin South, facing East", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Fin North, facing East", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Fin North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[3].Closed);
            Shapes[4] = new Shape(this, "Fin East, facing North", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Fin West, facing North", closed);

            closed = Shape.FlipBitmapVertically(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Fin West, facing South", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Fin East, facing South", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[8] = new Shape(this, "Fin down, facing West", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[9] = new Shape(this, "Fin up, facing West", closed);

            closed = Shape.RotateBitmapToward(Shapes[4].Closed);
            Shapes[10] = new Shape(this, "Fin East, facing up", closed);

            closed = Shape.RotateBitmapAway(Shapes[4].Closed);
            Shapes[11] = new Shape(this, "Fin East, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[12] = new Shape(this, "Fin down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[12].Closed);
            Shapes[13] = new Shape(this, "Fin down, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[13].Closed);
            Shapes[14] = new Shape(this, "Fin down, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[15] = new Shape(this, "Fin up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[15].Closed);
            Shapes[16] = new Shape(this, "Fin up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[16].Closed);
            Shapes[17] = new Shape(this, "Fin up, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[18] = new Shape(this, "Fin South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[18].Closed);
            Shapes[19] = new Shape(this, "Fin West, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[19].Closed);
            Shapes[20] = new Shape(this, "Fin North, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[11].Closed);
            Shapes[21] = new Shape(this, "Fin South, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[21].Closed);
            Shapes[22] = new Shape(this, "Fin West, facing down", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[22].Closed);
            Shapes[23] = new Shape(this, "Fin North, facing down", closed);

        }
        public enum Orientation
        {
            FinSouthFacingWest,
            FinSouthFacingEast,
            FinNorthFacingEast,
            FinNorthFacingWest,
            FinEastFacingNorth,
            FinWestFacingNorth,
            FinWestFacingSouth,
            FinEastFacingSouth,
            FinDownFacingWest,
            FinUpFacingWest,
            FinEastFacingUp,
            FinEastFacingDown,
            FinDownFacingNorth,
            FinDownFacingEast,
            FinDownFacingSouth,
            FinUpFacingNorth,
            FinUpFacingEast,
            FinUpFacingSouth,
            FinSouthFacingUp,
            FinWestFacingUp,
            FinNorthFacingUp,
            FinSouthFacingDown,
            FinWestFacingDown,
            FinNorthFacingDown
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
            Shapes = new Shape[12];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 0), new Pt(1, 0), new Pt(1, 1), new Pt(1, 2), new Pt(2, 2) };
            Shapes[0] = new Shape(this, "Tail North, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Tail North, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Tail East, Facing South", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Tail West, Facing South", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[4] = new Shape(this, "Tail up, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[4].Closed);
            Shapes[5] = new Shape(this, "Tail up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[5].Closed);
            Shapes[6] = new Shape(this, "Tail up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Tail up, facing South", closed);

            closed = Shape.RotateBitmapAway(Shapes[2].Closed);
            Shapes[8] = new Shape(this, "Tail East, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[9] = new Shape(this, "Tail South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[10] = new Shape(this, "Tail West, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[11] = new Shape(this, "Tail North, facing up", closed);
        }
        public enum Orientation
        {
            TailNorthFacingWest,
            TailNorthFacingEast,
            TailEastFacingSouth,
            TailWestFacingSouth,
            TailUpFacingWest,
            TailUpFacingNorth,
            TailUpFacingEast,
            TailUpFacingSouth,
            TailEastFacingUp,
            TailSouthFacingUp,
            TailWestFacingUp,
            TailNorthFacingUp
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
            Shapes = new Shape[12];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 2), new Pt(1, 0), new Pt(1, 1), new Pt(1, 2), new Pt(2, 2) };
            Shapes[0] = new Shape(this, "Head North, facing up", closed);

            closed = Shape.FlipBitmapVertically(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Head South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Head West, facing up", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Head East, facing up", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[4] = new Shape(this, "Head up, facing South", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[5] = new Shape(this, "Head down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[4].Closed);
            Shapes[6] = new Shape(this, "Head up, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[5].Closed);
            Shapes[7] = new Shape(this, "Head down, facing East", closed);

            closed = Shape.RotateBitmapToward(Shapes[2].Closed);
            Shapes[8] = new Shape(this, "Head West, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[9] = new Shape(this, "Head North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[10] = new Shape(this, "Head East, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[11] = new Shape(this, "Head South, facing East", closed);

        }
        public enum Orientation
        {
            HeadNorthFacingUp,
            HeadSouthFacingUp,
            HeadWestFacingUp,
            HeadEastFacingUp,
            HeadUpFacingSouth,
            HeadDownFacingNorth,
            HeadUpFacingWest,
            HeadDownFacingEast,
            HeadWestFacingSouth,
            HeadNorthFacingWest,
            HeadEastFacingNorth,
            HeadSouthFacingEast
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
            Shapes = new Shape[12];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 0), new Pt(0, 1), new Pt(1, 0), new Pt(2, 0), new Pt(2, 1) };
            Shapes[0] = new Shape(this, "Claws North, facing up", closed);

            closed = Shape.FlipBitmapVertically(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Claws South, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Claws West, facing up", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Claws East, facing up", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[4] = new Shape(this, "Claws up, facing South", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[5] = new Shape(this, "Claws down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[4].Closed);
            Shapes[6] = new Shape(this, "Claws up, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[5].Closed);
            Shapes[7] = new Shape(this, "Claws down, facing East", closed);

            closed = Shape.RotateBitmapToward(Shapes[2].Closed);
            Shapes[8] = new Shape(this, "Claws West, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[8].Closed);
            Shapes[9] = new Shape(this, "Claws North, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[10] = new Shape(this, "Claws East, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[11] = new Shape(this, "Claws South, facing East", closed);

        }
        public enum Orientation
        {
            ClawsNorthFacingUp,
            ClawsSouthFacingUp,
            ClawsWestFacingUp,
            ClawsEastFacingUp,
            ClawsUpFacingSouth,
            ClawsDownFacingNorth,
            ClawsUpFacingWest,
            ClawsDownFacingEast,
            ClawsWestFacingSouth,
            ClawsNorthFacingWest,
            ClawsEastFacingNorth,
            ClawsSouthFacingEast
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
            Shapes = new Shape[12];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 0), new Pt(1, 0), new Pt(2, 0), new Pt(2, 1), new Pt(2, 2) };
            Shapes[0] = new Shape(this, "Tail North, facing West", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Tail North, facing East", closed);

            closed = Shape.FlipBitmapVertically(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Tail South, facing East", closed);

            closed = Shape.FlipBitmapHorizontally(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Tail South facing West", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[4] = new Shape(this, "Tail up, facing West", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[5] = new Shape(this, "Tail down, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[4].Closed);
            Shapes[6] = new Shape(this, "Tail up, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Tail up, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[7].Closed);
            Shapes[8] = new Shape(this, "Tail up, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[5].Closed);
            Shapes[9] = new Shape(this, "Tail down, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[10] = new Shape(this, "Tail down, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[11] = new Shape(this, "Tail down, facing South", closed);
        }
        public enum Orientation
        {
            TailNorthFacingWest,
            TailNorthFacingEast,
            TailSouthFacingEast,
            TailSouthFacingWest,
            TailUpFacingWest,
            TailDownFacingWest,
            TailUpFacingNorth,
            TailUpFacingEast,
            TailUpFacingSouth,
            TailDownFacingNorth,
            TailDownFacingEast,
            TailDownFacingSouth
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
            Shapes = new Shape[12];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 2), new Pt(1, 1), new Pt(1, 2), new Pt(2,0), new Pt(2, 1) };
            Shapes[0] = new Shape(this, "Head Northeast, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Head Southeast, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Head Southwest, facing up", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[2].Closed);
            Shapes[3] = new Shape(this, "Head Northwest, facing up", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[4] = new Shape(this, "Head up-East, facing South", closed);

            closed = Shape.RotateBitmapAway(Shapes[0].Closed);
            Shapes[5] = new Shape(this, "Head down-East, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[4].Closed);
            Shapes[6] = new Shape(this, "Head up-South, facing West", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[6].Closed);
            Shapes[7] = new Shape(this, "Head up-West, facing North", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[7].Closed);
            Shapes[8] = new Shape(this, "Head up-North, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[5].Closed);
            Shapes[9] = new Shape(this, "Head down-South, facing East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[9].Closed);
            Shapes[10] = new Shape(this, "Head down-West, facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[10].Closed);
            Shapes[11] = new Shape(this, "Head down-North, facing West", closed);
        }
        public enum Orientation
        {
            HeadNortheastFacingUp,
            HeadSoutheastFacingUp,
            HeadSouthwestFacingUp,
            HeadNorthwestFacingUp,
            HeadUpEastFacingSouth,
            HeadDownEastFacingNorth,
            HeadUpSouthFacingWest,
            HeadUpWestFacingNorth,
            HeadUpNorthFacingEast,
            HeadDownSouthFacingEast,
            HeadDownWestFacingSouth,
            HeadDownNorthFacingWest
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
            Shapes = new Shape[3];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 0), new Pt(1, 0), new Pt(2, 0), new Pt(3, 0), new Pt(4, 0) };
            Shapes[0] = new Shape(this, "Head East", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Head North", closed);

            closed = Shape.RotateBitmapToward(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Head up", closed);


        }
        public enum Orientation
        {
            HeadEast,
            HeadNorth,
            HeadUp
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
            Shapes = new Shape[3];
            HashSet<Pt> closed;

            closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(1, 0), new Pt(1, 1), new Pt(1, 2), new Pt(2, 1) };
            Shapes[0] = new Shape(this, "Facing up", closed);

            closed = Shape.RotateBitmapToward(Shapes[0].Closed);
            Shapes[1] = new Shape(this, "Facing South", closed);

            closed = Shape.RotateBitmapClockwise(Shapes[1].Closed);
            Shapes[2] = new Shape(this, "Facing West", closed);
        }
        public enum Orientation
        {
            FacingUp,
            FacingSouth,
            FacingWest
        }
        public Shape GetShape(Orientation orientation)
        {
            return Shapes[(int)orientation];
        }
    }

}
