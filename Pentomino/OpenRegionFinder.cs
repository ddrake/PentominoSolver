using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class OpenRegionFinder
    {
        public OpenRegionFinder(HashSet<Location> open, HashSet<Location> closed)
        {
            Open = open;
            Closed = closed;
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

        private static HashSet<Location> Neighbors(Location loc)
        {
            return new HashSet<Location>() { 
                new Location(loc.x - 1, loc.y), new Location(loc.x + 1, loc.y),
                new Location(loc.x, loc.y-1), new Location(loc.x, loc.y+1) };
        }

        private void CheckLocation(Location loc, HashSet<Location> tested, HashSet<Location> currentRegion)
        {
            HashSet<Location> toCheck = Neighbors(loc);
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

