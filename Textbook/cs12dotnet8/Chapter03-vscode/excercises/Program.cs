string? num1 = ReadLine();
string? num2 = ReadLine();

try
{
  if (num1 == null || num2 == null)
  {
    Write("null input");
    return;
  }
  int int1 = int.Parse(num1);
  int int2 = int.Parse(num2);

  WriteLine($"{int1} divided by {int2} is {int1 / int2}");
}
catch (FormatException)
{
  WriteLine("Input string was not in a correct format");
}