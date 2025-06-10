using static System.Convert;
using System.Globalization;


int a = 10;
double b = a;
WriteLine($"a is {a}, b is {b}");

double c = 9.8;
int d = (int)c;
WriteLine($"c is {c}, d is {d}");

long e = 10;
int f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

e = long.MaxValue;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");

double g = 9.8;
int h = ToInt32(g);
WriteLine($"g is {g}, h is {h}");

byte[] binaryObject = new byte[128];

Random.Shared.NextBytes(binaryObject);

WriteLine("Binary Object as bytes:");

for (int index = 0; index < binaryObject.Length; index++)
{
  WriteLine($"{binaryObject[index]:X2} ");
}
WriteLine();

string encoded = ToBase64String(binaryObject);
WriteLine($"Binay Object as Base64: {encoded}");

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

int friends = int.Parse("27");
DateTime birthday = DateTime.Parse("4 June 1980");
WriteLine($"I have {friends} friends to invite to my party.");
WriteLine($"My birthday is {birthday}");
WriteLine($"My birthday is {birthday:D}");

Write("How many eggs are there?");
string? input = ReadLine();

if (int.TryParse(input, out int count))
{
  WriteLine($"There are {count} eggs.");
}
else
{
  WriteLine("I could not parse the input.");
}

bool success = Uri.TryCreate("https://localhost:5000/api/customers", UriKind.Absolute, out Uri serviceUrl);

