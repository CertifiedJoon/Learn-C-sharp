using System.Data.SqlTypes;

WriteLine("Before parsing");
Write("What is your age?");
string? input = ReadLine();

try
{
  if (input is null)
  {
    WriteLine("you did not enter a value so the app has ended.");
    return;
  }
  int age = int.Parse(input);
  WriteLine($"You are {age} years old.");
}
catch (FormatException) when (input.Contains("#"))
{
  WriteLine("Age cannot contain #");
}
catch (FormatException)
{
  WriteLine("The age you entered is not a valid number format.");
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()} says {ex.Message}");
}

WriteLine("After paring");


int x = int.MaxValue - 1;

WriteLine($"Initial value: {x}");
x++;
WriteLine($"After incrementing: {x}");
x++;
WriteLine($"After incrementing: {x}");
x++;
WriteLine($"After incrementing: {x}");

checked
{
  try
  {
    x = int.MaxValue - 1;
    WriteLine($"Initial value: {x}");
    x++;
    WriteLine($"After incrementing: {x}");
    x++;
    WriteLine($"After incrementing: {x}");
    x++;
    WriteLine($"After incrementing: {x}");
  }
  catch (OverflowException)
  {
    WriteLine("Overflow detected.");
  }

}