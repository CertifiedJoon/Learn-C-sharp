int x = 0;
while (x < 10)
{
  WriteLine(x);
  x++;
}

string? actualPassword = "Pa$$w0rd";
string? password;
int wrongPasswordCounter = 0;

do
{
  Write("Enter your password: ");
  password = ReadLine();
  wrongPasswordCounter++;
}
while (password != actualPassword & wrongPasswordCounter <= 3);

if (wrongPasswordCounter <= 3)
{
  WriteLine("Correct!");
}
else
{
  WriteLine("Password attempts exceeded.");
}

for (int y = 1; y <= 10; y += 3)
{
  WriteLine(y);
}

string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
  WriteLine($"{name} has {name.Length} characters.");
}

// IEnumerator e = names.GetEnumerator();

// while (e.MoveNext())
// {
//   string name = (string)e.Current;
//   WriteLine($"{name} has {name.Length} characters.");
// }