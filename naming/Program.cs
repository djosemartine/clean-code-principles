Console.WriteLine("Why naming matters?");
var prices = new List<decimal>() { 5.50m, 1.48m, 3.50m };
decimal total = 0;
foreach (var price in prices)
{
  total += price;
}
Console.WriteLine($"Total: {total}");