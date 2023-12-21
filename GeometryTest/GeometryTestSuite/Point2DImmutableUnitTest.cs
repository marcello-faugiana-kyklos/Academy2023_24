using Geometry.Core.Points;

namespace GeometryTestSuite
{
    public class Point2DImmutableUnitTest
    {

        [Fact]
        public void NewFromX_3_should_create_a_point_with_x_3_and_y_0()
        {
            Point2DImmutable p1 = Point2DImmutable.NewFromX(3);

            Assert.Equal(3d, p1.X);
            Assert.Equal(0d, p1.Y);
        }

        [Fact]
        public void DistanceFromOrigin_of_Point_3_4_should_be_5()
        {
            Point2DImmutable p1 = new Point2DImmutable(3, 4);
            var distance = p1.DistanceFromOrigin();

            Assert.Equal(5d, distance);
        }

        [Fact]
        public void DistanceFromOtherPoint_should_be_commutative()
        {
            Point2DImmutable p1 = new Point2DImmutable(3, 4);
            Point2DImmutable p2 = new Point2DImmutable(1, 6);

            var distance_p1_p2 = p1.DistanceFromOtherPoint(p2);
            var distance_p2_p1 = p2.DistanceFromOtherPoint(p1);

            //Assert.Equal(distance_p1_p2, distance_p2_p1);

            Assert.True(distance_p1_p2 == distance_p2_p1);
        }

        [Fact]
        public void Point_with_0_0_should_be_equal_to_point_Zero()
        {
            Point2DImmutable p1 = new Point2DImmutable();
            Assert.Equal(Point2DImmutable.Zero, p1);
        }

        [Fact]
        public void Sum_should_work()
        {
            Point2DImmutable p1 = new Point2DImmutable(1, 2);
            Point2DImmutable p2 = new Point2DImmutable(4, 5);

            Point2DImmutable p3 = p1 + p2;
            Point2DImmutable p4 = p1.Sum(p2);

            Assert.Equal(new Point2DImmutable(5, 7), p3);
        }

        [Fact]
        public void Subtract_should_work()
        {
            Point2DImmutable p1 = new Point2DImmutable(4, 5);
            Point2DImmutable p2 = new Point2DImmutable(1, 2);
            
            Point2DImmutable p3 = p1 - p2;

            Assert.Equal(new Point2DImmutable(3, 3), p3);
        }

        [Fact]
        public void Equality_Operator_should_work()
        {
            Point2DImmutable p1 = new Point2DImmutable(4, 5);
            Point2DImmutable p2 = new Point2DImmutable(4, 5);

            bool areEquals = p1 == p2;

            Assert.True(areEquals);

            Point2DImmutable p3 = new Point2DImmutable(2, 6);
            p3 = null;
            Assert.False(p1.Equals(p3));  
            Assert.False(p3 == p1);

        }

        [Fact]
        public void TestCoalesceOperator()
        {
            IPoint2DImmutable p1 = new Point2DImmutable(1, 2);
            IPoint2DImmutable p2 = new Point2DImmutable(1, 2);

            p1.DistanceFromOtherPoint(p2);
        }

    }
}