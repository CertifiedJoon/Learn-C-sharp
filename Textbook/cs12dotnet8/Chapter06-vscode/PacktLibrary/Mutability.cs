namespace Packt.Shared;

public record class C1
{
  public string? Name { get; set; }
}

public record class C2(string? Name);

public record struct S1
{
  public string? Name { get; set; }
}

public record struct S2(string? Name);

public readonly record struct S3(string? Name);