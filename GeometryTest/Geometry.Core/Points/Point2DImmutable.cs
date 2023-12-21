namespace Geometry.Core.Points;

public class Point2DImmutable : IEquatable<Point2DImmutable>, IPoint2DImmutable
{
    public static readonly Point2DImmutable Zero =
        new Point2DImmutable();

    public double X { get; }
    public double Y { get; }

    public Point2DImmutable(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Point2DImmutable() : this(0, 0)
    {
    }

    public static Point2DImmutable NewFromX(double x) =>
        new Point2DImmutable(x, 0);

    public static Point2DImmutable NewFromY(double y) =>
        new Point2DImmutable(0, y);

    public override string ToString() =>
       $"({X}, {Y})";

    public override bool Equals(object? obj) =>
        Equals(obj as Point2DImmutable);

    public bool Equals(Point2DImmutable? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() =>
        HashCode.Combine(X, Y);

    public double DistanceFromOrigin() =>
        DistanceFromOtherPoint(Zero);

    public double DistanceFromOtherPoint(IObjectWithXAndY other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }
        double sumOfSquaresOfDifferences =
            Math.Pow(X - other.X, 2)
            +
            Math.Pow(Y - other.Y, 2);

        return Math.Sqrt(sumOfSquaresOfDifferences);
    }

    public virtual Point2DImmutable SetCoordinates(double x, double y) =>
        new Point2DImmutable(x, y);

    public Point2DImmutable Sum(IPoint2DImmutable other) =>
        Sum(this, other);

    public static Point2DImmutable Sum(IPoint2DImmutable p1, IPoint2DImmutable p2)
    {
        if (p1 is null)
        {
            throw new ArgumentNullException(nameof(p1));
        }

        if (p2 is null)
        {
            throw new ArgumentNullException(nameof(p2));
        }

        return new Point2DImmutable(p1.X + p2.X, p1.Y + p2.Y);
    }

    public static Point2DImmutable operator +(Point2DImmutable p1, Point2DImmutable p2) =>
        Sum(p1, p2);

    public Point2DImmutable Subtract(IPoint2DImmutable other) =>
        Subtract(this, other);

    public static Point2DImmutable Subtract(IPoint2DImmutable p1, IPoint2DImmutable p2)
    {
        if (p1 is null)
        {
            throw new ArgumentNullException(nameof(p1));
        }

        if (p2 is null)
        {
            throw new ArgumentNullException(nameof(p2));
        }

        return new Point2DImmutable(p1.X - p2.X, p1.Y - p2.Y);
    }

    public static Point2DImmutable operator -(Point2DImmutable p1, Point2DImmutable p2) =>
        Subtract(p1, p2);

    public static bool operator ==(Point2DImmutable p1, Point2DImmutable p2) =>
        p1?.Equals(p2) ?? false;
    //{
    //if (p1 is null)
    //{
    //    return false;
    //}
    //return p1.Equals(p2);
    //}

    //private bool CoalesceTest()
    //{
    // p1?.M1()?.M2()?.M3() ?? ""

    /*
     *  if (p1 is null)
     *     return ""
     * 
     *  var m1 = p1.M1();
     *  
     *  if (m1 is null)
     *     return "";
     *     
     *  var m2 = m1.M2();
     *  
     *  if (m2 is null)
     *    return "";
     * 
     * var m3 = m2.M3();
     * 
     * if (m2 is null)
     *    return "";
     *    
     *  return m3;
     * 
     */
    //}

    public static bool operator !=(Point2DImmutable p1, Point2DImmutable p2) =>
        !(p1 == p2);

}
