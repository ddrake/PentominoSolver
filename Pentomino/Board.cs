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
            if (width * height % 5 != 0) throw new ArgumentException("Board size must be a multiple of 5");
            Spaces = new HashSet<Pt>();
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j )
                {
                    Spaces.Add(new Pt(i, j));
                }
            }
            Initialize();
        }

        public Board(HashSet<Pt> spaces)
        {
            if (spaces.Count % 5 != 0) throw new ArgumentException("Board size must be a multiple of 5");
            Spaces = spaces;
            Initialize();
        }

        private void Initialize()
        {
            Closed = new HashSet<Pt>();
            Open = new HashSet<Pt>(Spaces);
            Placements = new List<Placement>();
            ResetCache();
        }

        public void ResetCache()
        {
            Tested = new Dictionary<BoardPiece, Placement[]>(100000);
        }

        public void Clear()
        {
            Closed = new HashSet<Pt>();
            Open = new HashSet<Pt>(Spaces);
            Placements = new List<Placement>();
        }

        public void Add(Placement placement)
        {
            Placements.Add(placement);
            placement.UpdateBitmap(Open, Closed, true);
        }

        public void Remove(Placement placement)
        {
            Placements.Remove(placement);
            placement.UpdateBitmap(Open, Closed, false);
        }

        public int Size { get { return Spaces.Count; } }
     
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
            return new OpenRegionFinder(Open, Closed).HasInvalidRegions();
        }


        private HashSet<Pt> Spaces { get; set; }
        private HashSet<Pt> Open { get; set; }
        private HashSet<Pt> Closed { get; set; }
        private Dictionary<BoardPiece, Placement[]> Tested { get; set; }

        private void AddPossiblePlacementsFor(Shape shape, HashSet<Placement> placements)
        {
            foreach (Pt start in Spaces)
            {
                if (CanFit(shape, start))
                {
                    placements.Add(new Placement(shape, start));
                }
            }
         }

        private bool CanFit(Shape shape, Pt start)
        {
            foreach (Pt pt in shape.Closed)
            {
                var offsetPt = new Pt(pt.x + start.x, pt.y + start.y);
                if (!Open.Contains(offsetPt)) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hashcode = 0;
            foreach (Pt loc in Closed)
            {
                hashcode ^= loc.GetHashCode();
            }
            return hashcode;
        }
    }

}
