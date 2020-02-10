using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<VaultKeep> Get(string userId)
        {
            string sql = "SELECT * FROM Vaults WHERE userId = @UserId;";
            return _db.Query<VaultKeep>(sql, new { userId });
        }

        internal VaultKeep GetByVaultId(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @Id";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
        }

        internal VaultKeep Create(VaultKeep VaultKeepData)
        {
            string sql =@"INSERT INTO vaults (name, description) VALUES (@Name, @Description); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, VaultKeepData);
            VaultKeepData.Id = id;
            return VaultKeepData;
        }

        internal void Delete(int id)
        {
           string sql = "DELETE FROM vaults WHERE id = @Id";
           _db.Execute(sql, new { id });
        }
    }
}