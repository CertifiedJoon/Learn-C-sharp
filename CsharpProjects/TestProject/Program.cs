Console.WriteLine("Signed integral types: ");

Console.WriteLine($"sbyte : {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short : {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int   : {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long  : {long.MinValue} to {long.MaxValue}");

Console.WriteLine("Unsigned integral types: ");

Console.WriteLine($"byte  : {byte.MinValue} to {byte.MaxValue}, 2^{Math.Ceiling(Math.Log2(byte.MaxValue))} numbers");
Console.WriteLine($"ushort: {ushort.MinValue} to {ushort.MaxValue}, 2^{Math.Ceiling(Math.Log2(ushort.MaxValue))} numbers");
Console.WriteLine($"uint  : {uint.MinValue} to {uint.MaxValue}, 2^{Math.Ceiling(Math.Log2(uint.MaxValue))} numbers");
Console.WriteLine($"ulong : {ulong.MinValue} to {ulong.MaxValue}, 2^{Math.Ceiling(Math.Log2(ulong.MaxValue))} numbers");

Console.WriteLine("");
Console.WriteLine("Floating point types");
Console.WriteLine($"float: {float.MinValue} to {float.MaxValue} with (~6-9 digits of precision)");
Console.WriteLine($"double: {double.MinValue} to {double.MaxValue} with (~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} with (~28-29 digits of precision)");