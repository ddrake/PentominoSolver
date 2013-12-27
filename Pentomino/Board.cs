using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentomino
{
    public class Board
    {
        private int width;
        private int height;
        private bool[,] bitmap;
        private List<Placement> placements;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.bitmap = new bool[width, height];
            Clear();
        }

        public void Clear()
        {
            Array.Clear(bitmap, 0, bitmap.Length);
            placements = new List<Placement>(12);
        }

        public List<Placement> Placements { get { return placements; } }

        public void Add(Placement placement)
        {
            placements.Add(placement);
            this.bitmap = placement.UpdateBitmap(this.bitmap, true);
        }

        public void Remove(Placement placement)
        {
            placements.Remove(placement);
            this.bitmap = placement.UpdateBitmap(this.bitmap, false);
        }

        public Placement[] PossiblePlacementsFor(Piece piece)
        {
            List<Placement> placements = new List<Placement>(50);
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    Location location = new Location(x, y);

                    foreach (Shape shape in piece.Shapes)
                    {
                        if (CanFit(shape, location))
                        {
                            placements.Add(new Placement(shape, location));
                        }
                    }
                }
                
            }
            return placements.ToArray<Placement>();
        }

        protected bool CanFit(Shape shape, Location location)
        {
            bool outOfRange;
            int offsetX, offsetY;
            int boundX = shape.Bitmap.GetLength(0); 
            int boundY = shape.Bitmap.GetLength(1);
            for (int x = 0; x < boundX; ++x) 
            {
                for (int y = 0; y < boundY; ++y)
                {
                    offsetX = location.x + x;
                    offsetY = location.y + y;
                    outOfRange = offsetX >= width || offsetY >= height;
                    if (outOfRange || (shape.Bitmap[x, y] && this.bitmap[offsetX, offsetY]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

       
    }
}
