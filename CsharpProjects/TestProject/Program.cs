int employeeLevel = 200;
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
}

Console.WriteLine($"{employeeName}, {title}");