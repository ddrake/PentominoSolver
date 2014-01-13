using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    
    public class Board
    {
        public List<Placement> Placements { get; private set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Bitmap = new bool[width, height];
            Placements = new List<Placement>(Game.PIECE_COUNT);
            EmptyHashString = HashString = PrevHashString = GetHashString();
            ResetCache();
        }

        public void ResetCache()
        {
            Tested = new Dictionary<string, Placement[]>(100000);
        }

        public void Clear()
        {
            Array.Clear(Bitmap, 0, Bitmap.Length);
            Placements = new List<Placement>(Game.PIECE_COUNT);
            HashString = String.Copy(EmptyHashString);
        }

        public void Add(Placement placement)
        {
            Placements.Add(placement);
            Bitmap = placement.UpdateBitmap(Bitmap, true);
            PrevHashString = String.Copy(HashString);
            HashString = GetHashString();
        }

        public void Remove(Placement placement)
        {
            Placements.Remove(placement);
            Bitmap = placement.UpdateBitmap(Bitmap, false);
            HashString = String.Copy(PrevHashString);
        }

        public Placement[] PossiblePlacementsFor(Piece piece)
        {
            Placement[] result;
            string key = piece.Name + HashString;
            if (Tested.TryGetValue(key, out result))
                return result;
            List<Placement> placements = new List<Placement>(50);
            foreach (Shape shape in piece.Shapes)
            {
                AddPossiblePlacementsFor(shape, placements);
            }
            result = placements.ToArray<Placement>();
            Tested.Add(key, result);
            return result;
        }

        public bool HasInvalidRegions()
        {
            var finder = new OpenRegionFinder(Bitmap);
            List<List<Location>> regions = finder.FindRegions();
            foreach (var region in regions)
            {
                if (region.Count % 5 != 0) return true;
            }
            return false;
        }


        private int Width { get; set; }
        private int Height { get; set; }
        private bool[,] Bitmap { get; set; }
        private string HashString { get; set; }
        private string PrevHashString { get; set; }
        private string EmptyHashString { get; set; }
        private Dictionary<string, Placement[]> Tested { get; set; }

        private void AddPossiblePlacementsFor(Shape shape, List<Placement> placements)
        {
            int maxWidth = Width - shape.Bitmap.GetLength(0) + 1;
            int maxHeight = Height - shape.Bitmap.GetLength(1) + 1;
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

        private bool CanFit(Shape shape, Location location)
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
                    if (shape.Bitmap[x, y] && Bitmap[offsetX, offsetY])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string GetHashString()
        {
            StringBuilder sb = new StringBuilder(60);
            foreach (bool x in Bitmap) sb.Append(x ? "1" : "0");
            return Convert.ToInt64(sb.ToString(),2).ToString("X");
        }

        private int Capacity() { return Width * Height / Game.PENTOMINO_SIZE; }
    }

}
