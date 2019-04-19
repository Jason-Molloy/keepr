using System.Collections.Generic;
using keepr.Repositories;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _vkr;
    public VaultKeepController(VaultKeepRepository vkr)
    {
      _vkr = vkr;
    }
    //Create
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultkeep)
    {
      VaultKeep newVaultKeep = _vkr.CreateVaultKeep(vaultkeep);
      if (newVaultKeep == null) { return BadRequest(); }
      return Ok(newVaultKeep);
    }

    //Get all keeps for a vault
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      IEnumerable<Keep> results = _vkr.GetVaultKeeps(vaultId);
      if (results == null) { return BadRequest(); }
      return Ok(results);
    }
    //Delete
    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.DeleteVaultKeep(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }
  }
}