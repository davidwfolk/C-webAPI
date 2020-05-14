using System;
using System.ComponentModel.DataAnnotations;

namespace birgershack
{

  public class Burger
  {
    [Required]
    [MinLength(5)]
    public string Title { get; set; }
    [Required]
    [MaxLength(140)]
    public string Description { get; set; }
    [Required]
    [Range(1, 1000)]
    public decimal Price { get; set; }
    public string Id { get; private set; }

    public Burger()
    {
      Id = Guid.NewGuid().ToString();
    }

    public Burger(string title, string description, decimal price)
    {
      Title = title;
      Description = description;
      Price = price;
      Id = Guid.NewGuid().ToString();
    }
  }
}