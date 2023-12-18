namespace Geometry.Core.Points;

public class Point2D : IEquatable<Point2D>
{
    private double _x;
    private double _y;


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

        if (_x == other._x && _y == other._y)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode() =>
        HashCode.Combine(_x, _y);





    /*
     *         1 1 0 0 1 0 1
     *         1 0 0 0 1 1 0
     *         
     *         
     * &       1 0 0 0 1 0 0     
     * |       1 1 0 0 1 1 1
     * ^       1 0 1 1 1 0 0
     * 
     * 
     */


}
