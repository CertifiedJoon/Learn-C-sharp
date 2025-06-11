namespace Packt.Shared;

public class Headset(string manufacturer, string productName)
{
  public string Manufacturer { get; set; } = manufacturer;
  public string ProductName { get; set; } = productName;

  public Headset() : this("Mirosoft", "HoloLens") { }
}