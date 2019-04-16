using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    //Add/Create Vault
    public Vault CreateVault(Vault vault)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaults (name, description, UserId, img, Private) 
      VALUES (@name, @description, @UserId, @img, @Private);
      SELECT LAST_INSERT_ID()
      ", vault);
        vault.Id = id;
        return vault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    //Get a all of a users Vaults
    public IEnumerable<Vault> GetVaultsForUser(string id)
    {
      return _db.Query<Vault>(@"
      SELECT * FROM vaults WHERE userid = @id
      ", new { id });
    }

    //Get a single vault
    public Vault GetAVault(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>(@"
      SELECT * FROM vaults WHERE id = @Id
      ", new { Id });
    }
    //Edit a Vault
    public Vault EditVault(int id, Vault editedVault)
    {
      try
      {
        string query = @"
        UPDATE vaults SET
        name = @editedVault.Name,
        description = @editedVault.Description,
        UserId = @editedVault.UserId,
        WHERE id = @id;
        SELECT * FROM vaults WHERE id = @id;
        ";
        return _db.QueryFirstOrDefault<Vault>(query, new { id, editedVault });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    //Delete a Vault
    public bool DeleteVault(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM vaults WHERE id = @id
      ", new { id });
      return success > 0;
    }
  }
}