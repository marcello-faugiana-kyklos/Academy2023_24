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


object p1 = new Point2D();
object p2 = new Point2D();
object p3 = p1;

PrintToConsole(p1);
PrintToConsole(p2);

Console.WriteLine(p1.Equals(p2));

List<object> list = new List<object>();

list.Add(p1);
list.Add(p2);
list.Add(p3);

bool isContained = list.Contains(p1);





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

