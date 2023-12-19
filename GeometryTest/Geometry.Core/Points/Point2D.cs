namespace Geometry.Core.Points;

public class Point2D : IEquatable<Point2D>
{
    private double _x;
    private double _y;


    private class Point2DZero : Point2D
    {
        public override void SetCoordinates(double x, double y)
        {
        }

        public override double X 
        { 
            get => base.X; 
            set { } 
        }

        public override double Y
        {
            get => base.Y;
            set { }
        }
    }

    public static readonly Point2D Zero = 
        new Point2DZero();
    
    //private static Point2D Zero1 => new Point2D();
    
    //private static Point2D Zero2 { get; }

    //static Point2D()
    //{
    //    Zero2 = new Point2D();
    //}


    public Point2D() : this(0d, 0d)
    {
    }

    public Point2D(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public static Point2D NewFromX(double x) =>
        new Point2D(x, 0);

    public static Point2D NewFromY(double y) =>
        new Point2D(0, y);

    public virtual double X
    {
        get => _x;
        set => _x = value;
    }

    public virtual double Y
    {
        get => _y;
        set => _y = value;
    }

    public virtual void SetCoordinates(double x, double y) =>
        (_x, _y) = (x, y);

    public override string ToString() =>
        $"({_x}, {_y})";

    public override bool Equals(object? obj) =>
        Equals(obj as Point2D);


    public bool Equals(Point2D? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other)) 
            return true;
 
        return _x == other._x && _y == other._y;
    }

    public override int GetHashCode() =>
        HashCode.Combine(_x, _y);


    /*
     *         1 1 0 0 1 0 1
     *         1 0 0 0 1 1 0
     *         
     *         
     * &       1 0 0 0 1 0 0     (AND logico bit a bit)
     * |       1 1 0 0 1 1 1     (OR logico bit a bit)
     * ^       0 1 0 0 0 1 1     (XOR logico bit a bit)
     * 
     * 
     */


    // DRY Don't Repeat Yourself
    // KISS Keep It Simple Stupid

    public double DistanceFromOrigin() =>
        DistanceFromOtherPoint(Zero);


    public double DistanceFromOtherPoint(Point2D other)
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

}
