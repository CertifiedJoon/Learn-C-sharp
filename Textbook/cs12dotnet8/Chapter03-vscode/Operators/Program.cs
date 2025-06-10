#region Exploring unary operators

int a = 3;
int b = a++;

WriteLine($"a is {a}, b is {b}");

int c = 3;
int d = ++c;

WriteLine($"c is {c}, d is {d}");

int e = 11;
int f = 3;

WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e * f = {e * f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}");

// if the first operand is a floating point number
// division also returns the floating point
double g = 11.0;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g / f = {g / f}");

// Assignment

int p = 6;
p += 3;
p -= 3;
p *= 3;
p /= 3;

// Null coalescing operators
string? authorName = null;

int maxLength = authorName?.Length ?? 30;

authorName ??= "unknown";

WriteLine($"author name has {authorName.Length} and is {authorName}");

// Logical Operators
bool z = true;
bool q = false;

WriteLine(z & q);
WriteLine(z | q);
WriteLine(z ^ q);
#endregion

static bool DoStuff()
{
  WriteLine("I am doing some stuff");
  return true;
}

WriteLine($"z && DoStuff() = {z && DoStuff()}");
WriteLine($"q && DoStuff() = {q && DoStuff()}");

// Bitwise Operators
WriteLine();
int x = 10;
int y = 6;

WriteLine($"Expression | Decimal | Binary");
WriteLine($"-----------------------------");
WriteLine($"x          | {x,7} | {x:B8}");
WriteLine($"y          | {y,7} | {y:B8}");
WriteLine($"x&y        | {x&y,7} | {x&y:B8}");
WriteLine($"x|y        | {x|y,7} | {x|y:B8}");
WriteLine($"x^y        | {x^y,7} | {x^y:B8}");
WriteLine($"x<<3       | {x<<3,7} | {x<<3:B8}");
WriteLine($"y>>1       | {y>>1,7} | {y>>1:B8}");