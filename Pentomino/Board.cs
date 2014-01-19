using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    
    public class Board
    {
        public List<Placement> Placements { get; private set; }

        public Board(int width, int depth, int height = 1)
        {
            if (width * depth * height % 5 != 0) throw new ArgumentException("Board size must be a multiple of 5");
            Spaces = new HashSet<Pt>();
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < depth; ++y )
                {
                    for (int z = 0; z < height; ++z )
                        Spaces.Add(new Pt(x, y, z));
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
            SetRectContainerSpaces();
            Closed = new HashSet<Pt>();
            Open = new HashSet<Pt>(Spaces);
            Placements = new List<Placement>();
            ResetCache();
        }

        private void SetRectContainerSpaces()
        {
            rectContainerSpaces = new HashSet<Pt>();
            var minX = Spaces.Min<Pt>((pt) => pt.x);
            var maxX = Spaces.Max<Pt>((pt) => pt.x);
            var minY = Spaces.Min<Pt>((pt) => pt.y);
            var maxY = Spaces.Max<Pt>((pt) => pt.y);
            var minZ = Spaces.Min<Pt>((pt) => pt.z);
            var maxZ = Spaces.Max<Pt>((pt) => pt.z);
            for (int x = minX; x <= maxX; ++x)
                for (int y = minY; y <= maxY; ++y)
                    for (int z = minZ; z <= maxZ; ++z)
                        rectContainerSpaces.Add(new Pt(x, y, z));

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

        private HashSet<Pt> rectContainerSpaces;
        private HashSet<Pt> Spaces { get; set; }
        private HashSet<Pt> RectContainerSpaces { get { return rectContainerSpaces; } }
	
        private HashSet<Pt> Open { get; set; }
        private HashSet<Pt> Closed { get; set; }
        private Dictionary<BoardPiece, Placement[]> Tested { get; set; }

        private void AddPossiblePlacementsFor(Shape shape, HashSet<Placement> placements)
        {
            foreach (Pt start in RectContainerSpaces)
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
                var offsetPt = new Pt(pt.x + start.x, pt.y + start.y, pt.z + start.z);
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
