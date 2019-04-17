using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    //Add VaultKeep (Keep to Vault)
    public VaultKeep CreateVaultKeep(VaultKeep vaultkeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (vaultId, keepId, userId)
        VALUES (@vaultId, @keepId, @userId);
        SELECT LAST_INSERT_ID();
        ", vaultkeep);
        vaultkeep.Id = id;
        return vaultkeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    //get all vaultkeeps for a vault

    public IEnumerable<VaultKeep> GetVaultKeeps(int id)
    {
      return _db.Query<VaultKeep>(@"
      SELECT * FROM vaultkeeps WHERE vaultid = @id
      ", new { id });
    }

    //delete a vaultkeep
    public bool DeleteVaultKeep(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM vaultkeeps WHERE id = @id
      ", new { id });
      return success > 0;
    }

  }
}