using System.Xml;

object height = 1.88;
object name = "Amir";

Console.WriteLine($"{name} is {height} meters tall.");

//int length1 = name.Length;
int length2 = ((string)name).Length;
Console.WriteLine($"{name} has {length2} chatacters.");

dynamic something;

something = new[] { 3, 5, 7 };
// something = 12;
// something = "Ahmed";
Console.WriteLine($"The length of something is {something.Length}");

Console.WriteLine($"something is a {something.GetType()}");

var population = 67_000_000;
var weight = 1.88;
var price = 4.99M;
var fruit = "Apples";
var letter = 'Z';
var happy = true;


// Good use of var. readers can infer the type from constructor.
var xml1 = new XmlDocument();
XmlDocument xml2 = new XmlDocument();


// bad use of var. readers cannot infer the type easily.
var file1 = File.CreateText("Something1.txt");
StreamWriter file2 = File.CreateText("something2.txt");

// target-typed new.
XmlDocument xml3 = new();

Console.WriteLine($"defualt(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");

int number = 13;
Console.WriteLine($"Number is : {number:N0}");
number = default;
Console.WriteLine($"Number is set to default : {number:N0}");
