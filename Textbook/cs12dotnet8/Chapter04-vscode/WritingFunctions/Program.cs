// TimesTable(7, 20);

ConfigureConsole(culture: "fr-FR");

decimal taxToPay = CalculateTax(amount: 149, twoLetterRegionCode: "FR");
WriteLine($"You must pay {taxToPay:C} in tax.");

static void RunCardinalToOrdinal()
{
  for (uint number = 1; number <= 1500; number++)
  {
    Write($"{CardinalToOrdinal(number)} ");
  }

  WriteLine();
}

RunCardinalToOrdinal();
RunFactorial();
RunFibFunctional();