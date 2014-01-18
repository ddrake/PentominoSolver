using System;
using System.Collections.Generic;
using System.Linq;
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
            this.location = new Location(x, y);
        }

        public override string ToString()
        {
            return String.Format("{0} at {1}", this.shape, this.location);
        }

        public void UpdateBitmap(HashSet<Location> open, HashSet<Location> bitmap, bool isAdding)
        {
            HashSet<Location> pieceMap = shape.Bitmap;
            foreach (Location loc in pieceMap)
            {
                var newLoc = new Location(loc.x + location.x, loc.y + location.y);
                if (isAdding) 
                {
                    open.Remove(newLoc);
                    bitmap.Add(newLoc);  
                }
                else
                {
                    open.Add(newLoc);
                    bitmap.Remove(newLoc);
                }
            }
        }

        public void RemovePieceFromList(List<Piece> pieces) { pieces.Remove(shape.Piece); }

        public void AddPieceToList(List<Piece> pieces) { pieces.Add(shape.Piece); }



        private Shape GetShape(Enum orientation)
        {
            Type type = orientation.GetType();

            if (type == typeof(Moose.Orientation))
                return new Moose().GetShape((Moose.Orientation)orientation);
            else if (type == typeof(Squirrel.Orientation))
                return new Squirrel().GetShape((Squirrel.Orientation)orientation);
            else if (type == typeof(Bat.Orientation))
                return new Bat().GetShape((Bat.Orientation)orientation);
            else if (type == typeof(Rabbit.Orientation))
                return new Rabbit().GetShape((Rabbit.Orientation)orientation);
            else if (type == typeof(Worm.Orientation))
                return new Worm().GetShape((Worm.Orientation)orientation);
            else if (type == typeof(Whale.Orientation))
                return new Whale().GetShape((Whale.Orientation)orientation);
            else if (type == typeof(Fish.Orientation))
                return new Fish().GetShape((Fish.Orientation)orientation);
            else if (type == typeof(Bird.Orientation))
                return new Bird().GetShape((Bird.Orientation)orientation);
            else if (type == typeof(Crab.Orientation))
                return new Crab().GetShape((Crab.Orientation)orientation);
            else if (type == typeof(Snail.Orientation))
                return new Snail().GetShape((Snail.Orientation)orientation);
            else if (type == typeof(Owl.Orientation))
                return new Owl().GetShape((Owl.Orientation)orientation);
            else if (type == typeof(Ram.Orientation))
                return new Ram().GetShape((Ram.Orientation)orientation);
            else
                throw new ArgumentException("Invalid orientation");
        }
    }
}
