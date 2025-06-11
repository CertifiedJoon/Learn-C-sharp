using System.ComponentModel;
using System.Globalization;
partial class Program
{
  static void TimesTable(byte number, byte size = 12)
  {
    WriteLine($"This is the {number} times table with {size} rows: ");
    WriteLine();

    for (int row = 1; row <= size; row++)
    {
      WriteLine($"{row} x {number} = {row * number}");
    }
    WriteLine();
  }

  static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
  {
    decimal rate = twoLetterRegionCode switch
    {
      "CH" => 0.08M,
      "DK" or "NO" => 0.25M,
      "GB" or "FR" => 0.2M,
      "HU" => 0.27M,
      "OR" or "AK" or "MT" => 0.0M,
      "ND" or "WI" or "ME" or "VA" => 0.05M,
      "CA" => 0.0825M,
      _ => 0.06M
    };

    return amount * rate;
  }

  static void ConfigureConsole(string culture = "en-US", bool useComputerCulture = false)
  {
    OutputEncoding = System.Text.Encoding.UTF8;

    if (!useComputerCulture)
    {
      CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
    }
    WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
  }

  /// <summary>
  /// Pass a 32-bit unsigned integer and it will be converted into its ordinal equivalent
  /// </summary>
  /// <param name="number">Number as a cordinal value e.g. 1,2,3, and so on</param>
  /// <returns>string Number as an ordinal value e.g 1st, 2nd, 3rd...</returns>
  static string CardinalToOrdinal(uint number)
  {
    uint lastTwoDigits = number % 100;

    switch (lastTwoDigits)
    {
      case 11:
      case 12:
      case 13:
        return $"{number:N0}th";
      default:
        uint lastDigit = number % 10;
        string suffix = lastDigit switch
        {
          1 => "st",
          2 => "nd",
          3 => "rd",
          _ => "th"
        };

        return $"{number:N0}{suffix}";
    }
  }

  static int Factorial(int number)
  {
    if (number < 0)
    {
      throw new ArgumentOutOfRangeException(
        message: $"Factorial undefined for negative numbers. Input {number}",
        paramName: nameof(number));
    }
    else if (number == 0)
    {
      return 1;
    }
    else
    {
      checked
      {
        return number * Factorial(number - 1);
      }
    }
  }

  static void RunFactorial()
  {
    for (int i = 1; i <= 15; i++)
    {
      try
      {
        WriteLine($"{i}! = {Factorial(i):N0}");
      }
      catch (OverflowException)
      {
        WriteLine($"{i}! is too large for a 32-bit integer.");
      }
      catch (Exception ex)
      {
        WriteLine($"{i}! throws {ex.GetType()}: {ex.Message}");
      }
    }
  }

  static int FibFunctional(uint term) => term switch
  {
    0 => throw new ArgumentOutOfRangeException(),
    1 => 0,
    2 => 1,
    _ => FibFunctional(term - 1) + FibFunctional(term - 2)
  };

  static void RunFibFunctional()
  {
    for (uint i = 1; i <= 30; i++)
    {
      WriteLine("The {0} term of the Fibonacci sequence is {1:N0}",
        arg0: CardinalToOrdinal(i),
        arg1: FibFunctional(term: i)
      );
    }
  }
}