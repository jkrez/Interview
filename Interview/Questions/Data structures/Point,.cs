namespace Questions.Data_structures
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("({Row}, {Column})")]
    public class Point : IEqualityComparer<Point>
    {
        public Point(int row, int column)
        {
            this.Column = column;
            this.Row = row;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public bool Equals(Point p1, Point p2)
        {
            return p1.Row == p2.Row && p1.Column == p2.Column;
        }

        public int GetHashCode(Point obj)
        {
            return this.Column.GetHashCode() * 17 * this.Row.GetHashCode();
        }
    }
}
