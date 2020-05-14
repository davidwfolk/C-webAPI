using System;
using System.Collections.Generic;
using birgershack.DB;
using Microsoft.AspNetCore.Mvc;

namespace birgershack
{

  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> GetAll()
    {
      try
      {
        return Ok(FakeDB.Burgers);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{burgerId}")]
    public ActionResult<Burger> GetOne(string burgerId)
    {
      try
      {
        Burger foundBurger = FakeDB.Burgers.Find(burger => burger.Id == burgerId);
        if (foundBurger == null)
        {
          throw new Exception("Invalid Id");
        }
        return Ok(foundBurger);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // [HttpGet("{burgerId}/ingredients")]
    // public ActionResult<Burger> GetIngredients(string burgerId)
    // {

    // }

    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        FakeDB.Burgers.Add(newBurger);
        return Created($"api/burgers/{newBurger.Id}", newBurger);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Burger> Edit(string id, [FromBody] Burger updatedBurger)
    {
      try
      {
        Burger burgerToUpdate = FakeDB.Burgers.Find(b => b.Id == id);
        if (burgerToUpdate == null)
        {
          throw new Exception("Invalid Id");
        }
        //NOTE if this was not required
        burgerToUpdate.Title = updatedBurger.Title == null ? burgerToUpdate.Title : updatedBurger.Title;
        burgerToUpdate.Description = updatedBurger.Description;
        burgerToUpdate.Price = updatedBurger.Price;
        return Ok(burgerToUpdate);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Burger burgerToDelete = FakeDB.Burgers.Find(b => b.Id == id);
        if (burgerToDelete == null)
        {
          throw new Exception("Invalid Id");
        }
        FakeDB.Burgers.Remove(burgerToDelete);
        return Ok("Delorted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }



  }


}