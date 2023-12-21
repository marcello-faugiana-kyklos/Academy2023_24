namespace Geometry.Core.Points
{
    public interface IObjectWithXAndY
    {
        double X { get; }
        double Y { get; }
    }

    public interface ICanComputeDistances
    {
        double DistanceFromOrigin();
        double DistanceFromOtherPoint(IObjectWithXAndY other);        
    }


    public interface IPoint2DImmutable : IObjectWithXAndY, ICanComputeDistances
    {
        bool Equals(Point2DImmutable? other);
        Point2DImmutable SetCoordinates(double x, double y);
        Point2DImmutable Sum(IPoint2DImmutable other);
        Point2DImmutable Subtract(IPoint2DImmutable other);
    }



}