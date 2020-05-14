using System.Collections.Generic;

namespace birgershack.DB
{
  public static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>()
    {
      new Burger("D$ Burger", "Its delicious", 5.00m),
      new Burger("Jake Burger", "Bacon Galore", 6.00m),
      new Burger("Mark Burger", "It's mostly just Ham", 7.00m)
    };
  }
}