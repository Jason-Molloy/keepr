using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //Add/Create Keep
    public Keep CreateKeep(Keep keep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
      INSERT INTO keeps (name, description, UserId, img, Private) 
      VALUES (@name, @description, @UserId, @img, @Private);
      SELECT LAST_INSERT_ID()", keep
        );
        keep.Id = id;
        return keep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public IEnumerable<Keep> GetKeepsForUser(string id)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps WHERE userid = @id
      ", new { id });
    }

    public IEnumerable<Keep> GetKeeps()
    {
      return _db.Query<Keep>(@"
      SELECT * FROM keeps
      "); //WHERE Private = false
    }

    //edit a keep
    public Keep EditKeep(int id, Keep editedKeep)
    {
      try
      {
        string query = @"
        UPDATE keeps SET
        name = @editedKeep.Name,
        description = @editedKeep.Description,
        UserId = @editedKeep.UserId,
        img = @editedKeep.img,
        Private = @editedKeep.Private
        WHERE id = @id;
        SELECT * FROM keeps WHERE id = @id;
        ";
        return _db.QueryFirstOrDefault<Keep>(query, new { id, editedKeep });
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    //Delete a Keep
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"
      DELETE FROM keeps WHERE id = @id
      ", new { id });
      return success > 0;
    }
  }
}