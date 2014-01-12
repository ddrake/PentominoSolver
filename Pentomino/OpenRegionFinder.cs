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
            this.open = new HashSet<Location>();
            this.closed = new HashSet<Location>();
            this.width = bitmap.GetLength(0);
            this.height = bitmap.GetLength(1);
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (bitmap[i, j]) closed.Add(new Location(i, j));
                    else open.Add(new Location(i, j));
                }
            }
        }
        HashSet<Location> open;
        HashSet<Location> closed;
        int width;
        int height;

        public List<List<Location>> FindRegions()
        {
            var results = new List<List<Location>>();
            var tested = new HashSet<Location>();
            var currentRegion = new HashSet<Location>();
            foreach (var o in this.open)
            {
                if (!tested.Contains(o))
                {
                    tested.Add(o);
                    currentRegion.Add(o);
                    CheckLocation(o, tested, currentRegion);
                    results.Add(currentRegion.ToList<Location>());
                    currentRegion = new HashSet<Location>();
                }
            }
            return results;
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
            HashSet<Location> toCheck = Neighbors(loc, width, height);
            toCheck.IntersectWith(this.open);
            foreach(Location location in toCheck)
            {
                if (!tested.Contains(location))
                {
                    tested.Add(location);
                    currentRegion.Add(location);
                    CheckLocation(location, tested, currentRegion);
                }
            }
        }
    }
}

