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
        public IEnumerable<VaultKeep> Get(string userId)
        {
            return _vaultKeepRepo.Get(userId);
        }
        internal VaultKeep GetByVaultId(int id, string userId)
        {
            var exists = _vaultKeepRepo.GetByVaultId(id);
            if (exists == null) { throw new Exception("No Vault exists with that Id"); }
            else if (exists.UserId != userId) { throw new Exception("Not your vault player"); }
            return exists;
        }

        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
            _vaultKeepRepo.Create(newVaultKeep);
            return newVaultKeep;
        }


        internal string Delete(int id)
        {
            var exists = _vaultKeepRepo.GetByVaultId(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            _vaultKeepRepo.Delete(id);
            return "Vault has been deleted!";
        }
    }
}