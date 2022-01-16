/// <summary>
///   This class is just a stupid sample of a bad naming pratice
/// </summary>
public static class StupidProgram
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Why naming matters?");
    var p = new List<decimal>() { 5.50m, 1.48m, 3.50m };
    decimal t = 0;
    foreach (var i in p)
    {
      t += i;
    }
    Console.WriteLine($"Result: {t}");
  }
}