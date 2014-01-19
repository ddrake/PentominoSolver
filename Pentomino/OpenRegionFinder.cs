using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class OpenRegionFinder
    {
        public OpenRegionFinder(HashSet<Pt> open, HashSet<Pt> closed)
        {
            Open = open;
            Closed = closed;
        }

        public List<List<Pt>> FindRegions()
        {
            var results = new List<List<Pt>>();
            var tested = new HashSet<Pt>();
            var currentRegion = new HashSet<Pt>();
            foreach (var open in Open)
            {
                if (!tested.Contains(open))
                {
                    AddLocationAndCheck(open, tested, currentRegion);
                    results.Add(currentRegion.ToList<Pt>());
                    currentRegion = new HashSet<Pt>();
                }
            }
            return results;
        }

        public bool HasInvalidRegions()
        {
            var tested = new HashSet<Pt>();
            var currentRegion = new HashSet<Pt>();
            foreach (var open in Open)
            {
                if (!tested.Contains(open))
                {
                    AddLocationAndCheck(open, tested, currentRegion);
                    if (currentRegion.Count % Game.PENTOMINO_SIZE != 0) return true;
                    currentRegion = new HashSet<Pt>();
                }
            }
            return false;
        }

        private HashSet<Pt> Open { get; set; }
        private HashSet<Pt> Closed { get; set; }

        private static HashSet<Pt> Neighbors(Pt loc)
        {
            return new HashSet<Pt>() { 
                new Pt(loc.x - 1, loc.y, loc.z), new Pt(loc.x + 1, loc.y, loc.z),
                new Pt(loc.x, loc.y - 1, loc.z), new Pt(loc.x, loc.y + 1, loc.z),
                new Pt(loc.x, loc.y, loc.z - 1), new Pt(loc.x, loc.y, loc.z + 1)
            };
        }

        private void CheckLocation(Pt loc, HashSet<Pt> tested, HashSet<Pt> currentRegion)
        {
            HashSet<Pt> toCheck = Neighbors(loc);
            toCheck.IntersectWith(Open);
            foreach(Pt location in toCheck)
            {
                if (!tested.Contains(location)) { AddLocationAndCheck(location, tested, currentRegion); }
            }
        }

        private void AddLocationAndCheck(Pt location, HashSet<Pt> tested, HashSet<Pt> currentRegion)
        {
            tested.Add(location);
            currentRegion.Add(location);
            CheckLocation(location, tested, currentRegion);
        }
    }
}

