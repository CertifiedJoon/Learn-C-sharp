namespace Packt.Shared;

public abstract class Shape
{
  public virtual double Width { get; set; }
  public virtual double Height { get; set; }

  public abstract double Area {get;}
}

public class Rectangle : Shape
{
  public Rectangle(double width, double height)
  {
    Width = width;
    Height = height;
  }

  public override double Area => Width * Height;
}

public class Square : Rectangle
{
  public Square(double height) : base(height, height) { }
}

public class Circle : Shape
{
  public Circle(double radius)
  {
    Width = 2 * radius;
    Height = 2 * radius;
  }

  public override double Area => Math.PI * (Height / 2) * (Height / 2);
}