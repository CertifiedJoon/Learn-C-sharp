using Microsoft.Win32.SafeHandles;
using Packt.Shared;
using Fruit = (string Name, int Number);
ConfigureConsole();


Person alice = new()
{
  Name = "Alice Jones",
  Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero),
  FavoriteAncientWonder = WondersOfTheAncientWorld.LighthouseOfAlexandria
};

WriteLine(format: "{0} was born on {1:D}.",
  arg0: alice.Name, arg1: alice.Born);



Person bob = new();
bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset(year: 1965, month: 12, day: 22, hour: 16, minute: 28, second: 0, offset: TimeSpan.FromHours(-5));
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = WondersOfTheAncientWorld.ColossusOfRhodes | WondersOfTheAncientWorld.HangingGardensOfBabylon;

WriteLine(format: "{0} was born on {1:D}. His favorite wonder is {2}",
  arg0: bob.Name, arg1: bob.Born, arg2:bob.FavoriteAncientWonder);
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");


Person alfred = new()
{
  Name = "Alfred"
};

bob.Children.Add(alfred);

bob.Children.Add(new Person { Name = "Bella" });
bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach (Person child in bob.Children)
{
  WriteLine($"> {child.Name}");
}

bob.WriteToConsole();
WriteLine(bob.GetOrigin());
WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));
WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5));
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
WriteLine(bob.OptionalParameters("Poke!", active: false));
int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
bob.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");

int e = 50;
int f = 60;
int g = 70;

WriteLine($"Before: e={e}, f={f}, g={g}, h doesn't exist yet!");
bob.PassingParameters(e, f, ref g, out int h);
WriteLine($"After: e={e}, f={f}, g={g}, h={h}");

Fruit fruit = bob.GetFruit();
WriteLine($"{fruit.Name}, {fruit.Number} there are.");

(string name, int number) = bob.GetFruit();
WriteLine($"{name}, {number}");

var (name1, dob1) = bob;
WriteLine($"Deconstructed person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed person: {name2}, {dob2}, {fav2}");


var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");



BankAccount.InterestRate = 0.012M;

BankAccount jonesAccount = new()
{
  AccountName = "Mrs. Jones",
  Balance = 2400
};

WriteLine(format: "{0} earned {1:C} interest.",
 arg0: jonesAccount.AccountName,
 arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new()
{
  AccountName = "Ms. Gerrier",
  Balance = 98
};

WriteLine(format: "{0} earned {1:C} interest.",
 arg0: gerrierAccount.AccountName,
 arg1: gerrierAccount.Balance * BankAccount.InterestRate);

// Book book = new()
// {
//   Isbn = "978-182376123",
//   Title = "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals"
// };

Book book = new(isbn: "978-1802387123", title: "C# 12 and .NET 8 - Modern Cross-Platform Development Fundamentals")
{
  Author = "Mark J.Price",
  PageCount = 821
};


WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
  book.Isbn, book.Title, book.Author, book.PageCount);

Person blankPerson = new();

WriteLine(format:
"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
  arg0: blankPerson.Name,
  arg1: blankPerson.HomePlanet,
  arg2: blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(format:
"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
  arg0: gunny.Name,
  arg1: gunny.HomePlanet,
  arg2: gunny.Instantiated);

int no = -1;

try
{
  WriteLine($"{no}! is {Person.Factorial(no)}");
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType()} says: {ex.Message}  number was {no}.");
}

Person sam = new()
{
  Name = "Sam",
  Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's Favoriate ice-cream flavor is {sam.FavoriteIceCream}.");

string color = "Jad";

try
{
  sam.FavoritePrimaryColor = color;
  WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");
}
catch (Exception ex)
{
  WriteLine("Tried to set {0} to {1}: {2}",
    nameof(sam.FavoritePrimaryColor), color, ex.Message);
}

sam.Children.Add(new() { Name = "Charlie",
 Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero) });
sam.Children.Add(new() { Name = "Ella",
 Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero) });
// Get using Children list.
WriteLine($"Sam's first child is {sam.Children[0].Name}.");
WriteLine($"Sam's second child is {sam.Children[1].Name}.");
// Get using the int indexer.
WriteLine($"Sam's first child is {sam[0].Name}.");
WriteLine($"Sam's second child is {sam[1].Name}.");
// Get using the string indexer.
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");

Passenger[] passengers = {
 new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
 new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
 new BusinessClassPassenger { Name = "Janice" },
 new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
 new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
  decimal flightCost = passenger switch
  {
    FirstClassPassenger p => p.AirMiles switch
    {
      > 35_000 => 1_500M,
      > 15_000 => 1_750M,
      _ => 2_000M
    },
    BusinessClassPassenger _ => 1_000M,
    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
    CoachClassPassenger _ => 650M,
    _ => 800M
  };
  WriteLine($"Flight costst {flightCost:C} for {passenger}");
}

ImmutablePerson jeff = new()
{
  FirstName = "Jeff",
  LastName = "Winger"
};
//jeff.FirstName = "Geoff";

ImmutableVehicle car = new()
{
  Brand = "Mazda MX-5 RF",
  Color = "Soul Red Crystal Metallic",
  Wheels = 4
};

ImmutableVehicle repaintedCar = car
  with
{ Color = "Polymetal Grey Metallic" };

WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");

AnimalClass ac1 = new() { Name = "Rex" };
AnimalClass ac2 = new() { Name = "Rex" };
WriteLine($"ac1 == ac2: {ac1 == ac2}");
AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };
WriteLine($"ar1 == ar2: {ar1 == ar2}");

ImmutableAnimal oscar = new("Oscar", "Lavrador");
var (who, what) = oscar;
WriteLine($"{who} is {what}");

Headset vp = new("Apple", "Vision Pro");
WriteLine($"{vp.ProductName} is made by {vp.Manufacturer}");

Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}.");
Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}.");