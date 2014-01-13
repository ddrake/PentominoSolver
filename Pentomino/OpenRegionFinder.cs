using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class OpenRegionFinder
    {
        public OpenRegionFinder(bool[,] bitmap)
        {
            Open = new HashSet<Location>();
            Closed = new HashSet<Location>();
            Width = bitmap.GetLength(0);
            Height = bitmap.GetLength(1);
            DivideIntoOpenAndClosedLocations(bitmap);
        }

        public List<List<Location>> FindRegions()
        {
            var results = new List<List<Location>>();
            var tested = new HashSet<Location>();
            var currentRegion = new HashSet<Location>();
            foreach (var open in Open)
            {
                if (!tested.Contains(open))
                {
                    AddLocationAndCheck(open, tested, currentRegion);
                    results.Add(currentRegion.ToList<Location>());
                    currentRegion = new HashSet<Location>();
                }
            }
            return results;
        }

        private HashSet<Location> Open { get; set; }
        private HashSet<Location> Closed { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }

        private void DivideIntoOpenAndClosedLocations(bool[,] bitmap)
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    if (bitmap[i, j]) Closed.Add(new Location(i, j));
                    else Open.Add(new Location(i, j));
                }
            }
        }

        private static HashSet<Location> Neighbors(Location loc, int width, int height)
        {
            var neighbors = new HashSet<Location>();
            if (loc.x > 0) neighbors.Add(new Location(loc.x - 1, loc.y));
            if (loc.x < width - 1 ) neighbors.Add(new Location(loc.x + 1, loc.y));
            if (loc.y > 0) neighbors.Add(new Location(loc.x, loc.y - 1));
            if (loc.y < height - 1) neighbors.Add(new Location(loc.x, loc.y + 1));

            return neighbors;
        }

        private void CheckLocation(Location loc, HashSet<Location> tested, HashSet<Location> currentRegion)
        {
            HashSet<Location> toCheck = Neighbors(loc, Width, Height);
            toCheck.IntersectWith(Open);
            foreach(Location location in toCheck)
            {
                if (!tested.Contains(location)) { AddLocationAndCheck(location, tested, currentRegion); }
            }
        }

        private void AddLocationAndCheck(Location location, HashSet<Location> tested, HashSet<Location> currentRegion)
        {
            tested.Add(location);
            currentRegion.Add(location);
            CheckLocation(location, tested, currentRegion);
        }
    }
}

