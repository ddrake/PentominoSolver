﻿using System;
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
            Spaces = new HashSet<Location>();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j )
                {
                    Spaces.Add(new Location(i, j));
                }
            }
            Bitmap = new HashSet<Location>();
            Open = new HashSet<Location>(Spaces);
            Placements = new List<Placement>();
            ResetCache();
        }

        public void ResetCache()
        {
            Tested = new Dictionary<BoardPiece, Placement[]>(100000);
        }

        public void Clear()
        {
            Bitmap = new HashSet<Location>();
            Open = new HashSet<Location>(Spaces);
            Placements = new List<Placement>();
        }

        public void Add(Placement placement)
        {
            Placements.Add(placement);
            placement.UpdateBitmap(Open, Bitmap, true);
        }

        public void Remove(Placement placement)
        {
            Placements.Remove(placement);
            placement.UpdateBitmap(Open, Bitmap, false);
        }

        public Placement[] PossiblePlacementsFor(Piece piece)
        {
            Placement[] result;
            BoardPiece bp = new BoardPiece(this, piece);
            if (Tested.TryGetValue(bp, out result))
                return result;
            HashSet<Placement> placements = new HashSet<Placement>();
            foreach (Shape shape in piece.Shapes)
            {
                AddPossiblePlacementsFor(shape, placements);
            }
            result = placements.ToArray<Placement>();
            Tested.Add(bp, result);
            return result;
        }

        public bool HasInvalidRegions()
        {
            var finder = new OpenRegionFinder(Open, Bitmap);
            List<List<Location>> regions = finder.FindRegions();
            foreach (var region in regions)
            {
                if (region.Count % 5 != 0) return true;
            }
            return false;
        }


        private HashSet<Location> Spaces { get; set; }
        private HashSet<Location> Open { get; set; }
        private HashSet<Location> Bitmap { get; set; }
        private Dictionary<BoardPiece, Placement[]> Tested { get; set; }

        private void AddPossiblePlacementsFor(Shape shape, HashSet<Placement> placements)
        {
            foreach (Location start in Spaces)
            {
                if (CanFit(shape, start))
                {
                    placements.Add(new Placement(shape, start));
                }
            }
         }

        private bool CanFit(Shape shape, Location start)
        {
            foreach (Location pt in shape.Bitmap)
            {
                var offsetPt = new Location(pt.x + start.x, pt.y + start.y);
                if (!Open.Contains(offsetPt)) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (Location loc in Bitmap)
            {
                hashcode ^= loc.GetHashCode();
            }
            return hashcode;
        }
    }

}
