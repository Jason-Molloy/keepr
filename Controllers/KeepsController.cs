using System.Collections.Generic;
using keepr.Repositories;
using Keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;
    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }

    //Get All
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetKeeps();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //Get All by user ID
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetForUser()
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _kr.GetKeepsForUser(UserId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //Create One
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keep)
    {
      keep.userId = HttpContext.User.Identity.Name;
      Keep newKeep = _kr.CreateKeep(keep);
      if (newKeep == null) { return BadRequest(); }
      return Ok(newKeep);
    }

    //Edit One
    [HttpPut("{id}")]
    public ActionResult<Keep> Update(int id, [FromBody] Keep editedKeep)
    {
      Keep updatedKeep = _kr.EditKeep(id, editedKeep);
      if (updatedKeep == null) { return BadRequest(); }
      return Ok(updatedKeep);
    }

    //Delete One
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.DeleteKeep(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }
  }
}