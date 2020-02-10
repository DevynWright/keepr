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
        internal string Create(VaultKeep newVaultKeep)
        {
            VaultKeep exists = _vaultKeepRepo.Find(newVaultKeep.KeepId, newVaultKeep.VaultId);
            if (exists == null)
            {
                _vaultKeepRepo.Create(newVaultKeep);
            }
            else if (exists != null)
            {
                return "already exists";

            }
            return "successfull";
        }


        internal string Delete(int vaultId, int keepId, string userId)
        {
            var exists = _vaultKeepRepo.GetById(vaultId, keepId);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            else if (exists.UserId != userId) { throw new Exception("not yours to delete killer");}
            _vaultKeepRepo.Delete(exists.Id);
            return "VaultKeep has been deleted!";
        }
    }
}