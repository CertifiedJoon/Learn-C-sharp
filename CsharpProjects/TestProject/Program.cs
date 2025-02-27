int employeeLevel = 400;
string employeeName = "John Smith";

string title = "";

switch (employeeLevel)
{
  case 100:
    title = "Junior Associate";
    break;
  case 200:
    title = "Senior Associate";
    break;
  case 300:
  case 400:
    title = "Boss";
    break;
}

Console.WriteLine($"{employeeName}, {title}");