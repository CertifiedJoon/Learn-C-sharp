using System.Diagnostics;
using static System.Console;

Write("Press Enter to start");
ReadLine();
Stopwatch watch = Stopwatch.StartNew();

int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start: 1, count: max);
WriteLine($"Calculating Fib sequence up to term {max}. Please wait...");

watch.Start();
int[] fibNumbers = numbers.Select(number => Fibonacci(number)).ToArray();
watch.Stop();

WriteLine("{0:#,##0} elapsed milliseconds.",
  arg0: watch.ElapsedMilliseconds);

Write("Results:");
foreach (int number in fibNumbers)
{
  Write($"  {number:N0}");
}

WriteLine($"Calculating Fib sequence up to term {max} in Parallel. Please wait...");
watch = Stopwatch.StartNew();
watch.Start();
fibNumbers = numbers.AsParallel().Select(number => Fibonacci(number)).ToArray();
watch.Stop();

WriteLine("{0:#,##0} elapsed milliseconds.",
  arg0: watch.ElapsedMilliseconds);

Write("Results:");
foreach (int number in fibNumbers)
{
  Write($"  {number:N0}");
}

static int Fibonacci(int term) =>
  term switch
  {
    1 => 0,
    2 => 1,
    _ => Fibonacci(term - 1) + Fibonacci(term - 2)
  };