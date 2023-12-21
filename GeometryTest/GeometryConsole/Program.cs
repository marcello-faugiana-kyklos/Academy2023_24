// See https://aka.ms/new-console-template for more information
using Geometry.Core.Points;
using System.Security.Cryptography;

void PrintToConsole(object? item)
{
	if (item is null)
	{
		Console.WriteLine("Passed argument is null!");
	}
	else
	{
		Console.WriteLine($"{item} is of type {item.GetType().FullName}");
	}
}


Point2D p1 = new Point2D();


object zero_o = Point2D.Zero;


Point2D.ComputeDistanceBetweenPoints(p1, Point2D.Zero);

Point2D.ComputeDistanceBetweenPoints(Point2D.Zero, p1);
p1.DistanceFromOtherPoint(Point2D.Zero);
Point2D.Zero.DistanceFromOtherPoint(p1);



Console.WriteLine(p1.Equals(zero_o));

//for (int i = 0; i < 100_000_000; i++)
//{
//    p1.DistanceFromOrigin();
//}

Console.WriteLine(p1.DistanceFromOrigin());
var zero = Point2D.Zero;
zero.X = 2;
zero.Y = 3;
Point2D.Zero.SetCoordinates(8, 10);
Console.WriteLine(p1.DistanceFromOrigin());



Point2D p4 = Point2D.NewFromX(3);
Point2D p5 = Point2D.NewFromY(5);
Console.WriteLine(p5.DistanceFromOtherPoint(p1));
Console.WriteLine(p1.DistanceFromOtherPoint(p5));

p1 = null;
double distance_5_1;
try
{
    distance_5_1 = p5.DistanceFromOtherPoint(p1);
}
catch (Exception ex)
{
	distance_5_1 = 0;
}

p1.DistanceFromOtherPoint(p5);

Point2D.ComputeDistanceBetweenPoints(p1, p5);


//try
//{
//    Console.WriteLine(p5.DistanceFromOtherPoint(null));
//}
//catch (ArgumentNullException ex)
//{
//	Console.WriteLine($"{ex.Message}");
//}


double x_of_p1 = p1.X;

p1.SetCoordinates(6, 9);
p1.X = 9;
p1.Y = 7;
x_of_p1 = p1.X;

object p2 = new Point2D(3, 4);
object p3 = p1;

PrintToConsole(p1);
PrintToConsole(p2);

Console.WriteLine(p1.Equals(p2));

//List<object> list = new List<object>();

//list.Add(p1);
//list.Add(p2);
//list.Add(p3);

//bool isContained = list.Contains(p1);





//PrintToConsole(p1);	

//p1 = DateTime.Today;
//PrintToConsole(p1);

//p1 = new object();
//PrintToConsole(p1);

//p1 = "Ciao Mondo!";
//PrintToConsole(p1);


//PrintToConsole(p2);

//PrintToConsole(null);





//DateTime d1 = DateTime.Now;

//Console.WriteLine($"{d1.ToString("yyyy-MM-ddTHH:mm:ss.fff")} is of type {d1.GetType().FullName}");



// TDD Test Driven Development


interface A
{
	
}

interface B : A
{
	public int M1();
}

interface C  : A
{
	public int M1();
}

class D : B, C
{
    public int M1()
    {
		return 1;
    }
}


/*
 *           A
 *          / \
 *         B   C
 *          \ /
 *           D
 *  
 * 
 *  D d = new D();
 * 
 * d.M1();
 * 
 */