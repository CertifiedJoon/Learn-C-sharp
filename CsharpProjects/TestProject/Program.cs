string[] pallets = [ "B14", "A11", "B12", "A13" ];

Console.WriteLine("Sorted...");
Array.Sort(pallets);

foreach (string pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Console.WriteLine("Reversed....");
Array.Reverse(pallets);

foreach (string pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Array.Clear(pallets, 0, 2);
Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
foreach (var pallet in pallets)
{
    Console.WriteLine($"-- {pallet}");
}

Console.WriteLine("");
Array.Resize(ref pallets, 6);
Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

pallets[4] = "C01";
pallets[5] = "C02";

foreach (string pallet in pallets)
{
    Console.WriteLine($" -- {pallet}");
}

string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
string result = String.Join(",", valueArray);
Console.WriteLine(result);

string[] items = result.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}

string pangram = "The quick brown fox jumps over the lazy dog";
string[] words = pangram.Split(" ");

for (int i = 0; i < words.Length; i++)
{
    words[i] = String.Join("", words[i].ToCharArray().Reverse());
}

Console.WriteLine(String.Join(" ", words));