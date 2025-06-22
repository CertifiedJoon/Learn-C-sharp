using System.Collections.Generic;

namespace System.Linq;

public static class LinqExtensions
{
  public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
  {
    return sequence;
  }

  public static IQueryable<T> ProcessSequence<T>(this IQueryable<T> sequence)
  {
    return sequence;
  }

  public static int? Median(this IEnumerable<int?> sequence)
  {
    var ordered = sequence.OrderBy(item => item);
    int middle = ordered.Count() / 2;
    return ordered.ElementAt(middle);
  }

  public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
  {
    return sequence.Select(selector).Median();
  }
}
