using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal IEnumerable<Keep> GetMyKeeps(string userId)
        {
            string sql = "SELECT * FROM Keeps WHERE userId = @userId;";
            return _db.Query<Keep>(sql, new { userId });
        }
        internal Keep Create(Keep newKeep)
        {
            string sql =@"
            INSERT INTO keeps
            (name, description, img, isPrivate, views, shares, keeps, userId)
            VALUES
            (@Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newKeep);
            newKeep.Id = id;
            return newKeep;
        }


        internal Keep GetById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @id;";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id;";
            _db.Execute(sql, new { id });
        }

        internal void Edit(Keep newKeep)
        {
            string sql =@"
            UPDATE keeps 
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            isPrivate = @IsPrivate,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
            WHERE id = @Id;
            ";
            _db.Execute(sql, newKeep);
        }
    }
}