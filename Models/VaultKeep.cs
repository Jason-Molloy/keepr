using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string userId { get; set; }
  }
}