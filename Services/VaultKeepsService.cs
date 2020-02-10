using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vaultKeepRepo;
        public VaultKeepsService(VaultKeepsRepository vaultKeepRepo)
        {
            _vaultKeepRepo = vaultKeepRepo;
        }
        public IEnumerable<Keep> GetByVaultId(int vaultId, string userId)
        {
            var exists = _vaultKeepRepo.GetByVaultId(vaultId, userId);
            if (exists == null) { throw new Exception("No Vault exists with that Id"); }
            return exists;
        }
        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            _vaultKeepRepo.Create(newVaultKeep);
            return newVaultKeep;
        }


        internal string Delete(int vaultId, int keepId)
        {
            var exists = _vaultKeepRepo.GetById(vaultId, keepId);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            _vaultKeepRepo.Delete(exists.Id);
            return "Vault has been deleted!";
        }
    }
}