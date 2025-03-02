using System.Security;

string[] values = { "12.3", "45", "ABC", "11", "DEF" };

decimal sum = 0.0M;
string msg = "";
decimal parsed;
foreach (string value in values) 
{
    if (decimal.TryParse(value, out parsed)) 
    {
        sum += parsed;
    } else {
        msg += value;
    }
}
Console.WriteLine($"Message: {msg}");
Console.WriteLine($"Total: {sum}");