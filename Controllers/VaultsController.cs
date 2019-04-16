using System.Collections.Generic;
using keepr.Repositories;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;
    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }
    //Get All
    // [HttpGet]
    // public ActionResult<IEnumerable<Vault>> Get()
    // {
    //   IEnumerable<Vault> results = _vr.GetVaultsForUser(UserId);
    // }

    //Get One vault by ID
    [HttpGet("{id}")]
    public ActionResult<Vault> GetVault(int id)
    {
      Vault found = _vr.GetAVault(id);
      if (found == null)
      {
        return BadRequest();
      }
      return Ok(found);
    }

    //Create One
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault vault)
    {
      Vault newVault = _vr.CreateVault(vault);
      if (newVault == null) { return BadRequest(); }
      return Ok(newVault);
    }

    //Edit One
    [HttpPut("{id}")]
    public ActionResult<Vault> Update(int id, [FromBody] Vault editedVault)
    {
      Vault updatedVault = _vr.EditVault(id, editedVault);
      if (updatedVault == null) { return BadRequest(); }
      return Ok(updatedVault);
    }

    //Delete One
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.DeleteVault(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }
  }
}