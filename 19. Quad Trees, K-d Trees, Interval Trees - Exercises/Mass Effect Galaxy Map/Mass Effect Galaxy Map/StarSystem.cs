using System;

public class StarSystem : IComparable<StarSystem>
{
    public string Name { get; set; }

    public int X { get; }

    public int Y { get; }

    public StarSystem(int x, int y, string name = "")
    {
        X = x;
        Y = y;
        Name = name;
    }

    public double GetDistance(StarSystem other)
    {
        return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
    }

    public bool IsInto(int x1, int y1, int x2, int y2)
    {
        return X >= x1 && X <= x2 && Y >= y1 && Y <= y2;
    }

    public override string ToString()
    {
        return $"{Name} {X} {Y}";
    }

    public override bool Equals(object obj)
    {
        if (obj == this) return true;
        if (obj == null) return false;
        if (obj.GetType() != GetType()) return false;
        var that = (StarSystem)obj;
        return X == that.X && Y == that.Y;
    }

    public override int GetHashCode()
    {
        var hashX = X.GetHashCode();
        var hashY = Y.GetHashCode();
        return 31 * hashX + hashY;
    }

    public int CompareTo(StarSystem other)
    {
        if (X < other.X) return -1;
        if (X > other.X) return +1;
        if (Y < other.Y) return -1;
        if (Y > other.Y) return +1;

        return 0;
    }
}
