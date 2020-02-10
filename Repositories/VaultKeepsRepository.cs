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
        internal IEnumerable<Keep> GetByVaultId(int vaultId, string userId)
        {
            string sql = "SELECT k.* FROM vaultkeeps vk INNER JOIN keeps k ON k.Id = vk.KeepId WHERE (vk.VaultId = @vaultId AND vk.UserId = @userId);";
            return _db.Query<Keep>(sql, new { vaultId, userId });
        }

        internal VaultKeep GetById(int vaultId, int keepId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE (VaultId = @vaultId And KeepId = @keepId);";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
        }

        internal VaultKeep Create(VaultKeep vaultKeepData)
        {
            string sql =@"INSERT INTO vaultkeeps (keepId, vaultId, userId) VALUES (@KeepId, @VaultId, @UserId); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            vaultKeepData.Id = id;
            return vaultKeepData;
        }

        internal void Delete(int id)
        {
           string sql = "DELETE FROM vaults WHERE id = @Id";
           _db.Execute(sql, new { id });
        }
    }
}