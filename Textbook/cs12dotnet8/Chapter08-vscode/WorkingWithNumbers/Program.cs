using System.Numerics;

const int width = 50;

WriteLine("ulong.MaxValue vs a 30-digit BigInteger");
WriteLine(new string('-', width));

ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");

// Random

Random r = Random.Shared;

int dieRoll = r.Next(minValue: 1, maxValue: 7);
WriteLine($"Randome die roll: {dieRoll}");

byte[] arrayOfBytes = new byte[256];
r.NextBytes(arrayOfBytes);
Write("Random bytes: ");
for (int i = 0; i < arrayOfBytes.Length; i++)
{
  Write($"{arrayOfBytes[i]:X2}");
}
WriteLine();

string[] beatles = r.GetItems(
  choices: new[] { "John", "Paul", "George", "Ringo" },
  length: 10
);

WriteLine("Random ten beatles: ");
foreach (string beatle in beatles)
{
  Write($"  {beatle}");
}
WriteLine();

r.Shuffle(beatles);

Write("Shuffled beatles");
foreach (string beatle in beatles)
{
  Write($" {beatle}");
}
WriteLine();

// GUID

WriteLine($"Empty GUID: {Guid.Empty}.");
Guid g = Guid.NewGuid();
WriteLine($"Random GUID: {g}.");

byte[] guidAsBytes = g.ToByteArray();
Write("GUID as byte array: ");
for (int i = 0; i < guidAsBytes.Length; i++)
{
  Write($"{guidAsBytes[i]:X2}");
}
WriteLine();

