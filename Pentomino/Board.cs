using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class Board
    {
        private int width;
        private int height;
        private bool[,] bitmap;
        private List<Placement> placements;
        private string hashString;
        private string prevHashString;
        private string emptyHashString;
        private Dictionary<string,Placement[]> tested;
        
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.bitmap = new bool[width, height];
            Array.Clear(bitmap, 0, bitmap.Length);
            placements = new List<Placement>(12);
            emptyHashString = hashString = prevHashString = HashString();
            tested = new Dictionary<string,Placement[]>(100000);
        }

        public void Clear()
        {
            Array.Clear(bitmap, 0, bitmap.Length);
            placements = new List<Placement>(12);
            this.hashString = String.Copy(emptyHashString);
        }

        public List<Placement> Placements { get { return placements; } }

        public void Add(Placement placement)
        {
            placements.Add(placement);
            this.bitmap = placement.UpdateBitmap(this.bitmap, true);
            this.prevHashString = String.Copy(hashString);
            this.hashString = HashString();
        }

        public void Remove(Placement placement)
        {
            placements.Remove(placement);
            this.bitmap = placement.UpdateBitmap(this.bitmap, false);
            this.hashString = String.Copy(prevHashString);
        }

        public Placement[] PossiblePlacementsFor(Piece piece)
        {
            Placement[] result;
            string key = piece.Name + this.hashString;
            if (this.tested.TryGetValue(key, out result))
                return result;
            List<Placement> placements = new List<Placement>(50);
            foreach (Shape shape in piece.Shapes)
            {
                int maxWidth = width - shape.Bitmap.GetLength(0) + 1;
                int maxHeight = height - shape.Bitmap.GetLength(1) + 1;
                for (int x = 0; x < maxWidth; ++x)
                {
                    for (int y = 0; y < maxHeight; ++y)
                    {
                        Location location = new Location(x, y);

                        if (CanFit(shape, location))
                        {
                            placements.Add(new Placement(shape, location));
                        }
                    }
                }
            }
            result = placements.ToArray<Placement>();
            this.tested.Add(key, result);
            return result;
        }

        protected bool CanFit(Shape shape, Location location)
        {
            int offsetX, offsetY;
            int boundX = shape.Bitmap.GetLength(0); 
            int boundY = shape.Bitmap.GetLength(1);
            for (int x = 0; x < boundX; ++x) 
            {
                for (int y = 0; y < boundY; ++y)
                {
                    offsetX = location.x + x;
                    offsetY = location.y + y;
                    if (shape.Bitmap[x, y] && this.bitmap[offsetX, offsetY])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        protected string HashString()
        {
            StringBuilder sb = new StringBuilder(60);
            foreach (bool x in this.bitmap) sb.Append(x ? "1" : "0");
            return Convert.ToInt64(sb.ToString(),2).ToString("X");
        }

        public bool InvalidRegions()
        {
            var finder = new OpenRegionFinder(bitmap);
            List<List<Location>> regions = finder.FindRegions();
            foreach(var region in regions)
            {
                if (region.Count % 5 != 0) return true;
            }
            return false;
        }

    }


}
