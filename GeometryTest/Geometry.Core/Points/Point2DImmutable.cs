namespace Geometry.Core.Points;

public class Point2DImmutable
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

    public double DistanceFromOtherPoint(Point2DImmutable other)
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

}
