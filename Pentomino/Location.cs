using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public struct Location
    {
        public int x, y;
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return String.Format("({0},{1})", x, y);
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }
}
