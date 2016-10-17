using System;

namespace SokoSolver
{
    class Coordinate : IComparable
    {
        public int row;
        public int col;

        public Coordinate(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public override int GetHashCode()
        {
            return row * 1000 + col;
        }

        public static bool operator == (Coordinate c1, Coordinate c2)
        {
            if (ReferenceEquals(c1, null)) return (ReferenceEquals(c2, null));
            return c1.row == c2.row && c1.col == c2.col;
        }

        public static bool operator != (Coordinate c1, Coordinate c2)
        {
            if (ReferenceEquals(c1, null) && !ReferenceEquals(c2, null)) return true;
            if (!ReferenceEquals(c1, null) && ReferenceEquals(c2, null)) return true;
            return (c1.row != c2.row || c1.col != c2.col);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate)) return false;

            Coordinate c = (Coordinate)obj;
            return row == c.row && col == c.col;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Coordinate c = (Coordinate)obj;
            if(this.col == c.col)
            {
                return this.row.CompareTo(c.row);
            }

            return this.col.CompareTo(c.col);
        }

        public bool Equals(Coordinate c)
        {
            if(c == null)
            {
                return false;
            }

            return row == c.row && col == c.col;
        }
    }
}
