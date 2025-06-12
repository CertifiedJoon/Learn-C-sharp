using System.Numerics;

namespace Packt.Shared;

public record struct DisplacementVector
{
  public int X { get; set; }
  public int Y { get; set; }

  #region  Constructors
  public DisplacementVector(int x, int y)
  {
    X = x;
    Y = y;
  }

  public static DisplacementVector operator +(DisplacementVector left, DisplacementVector right)
  {
    return new (left.X + right.X, left.Y + right.Y);
  }
  #endregion
}