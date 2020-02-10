using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vaultRepo;
        public VaultsService(VaultsRepository vaultRepo)
        {
            _vaultRepo = vaultRepo;
        }
        public IEnumerable<Vault> Get(string userId)
        {
            return _vaultRepo.Get(userId);
        }
        internal Vault GetById(int id, string userId)
        {
            var exists = _vaultRepo.GetById(id);
            if (exists == null) { throw new Exception("No Vault exists with that Id"); }
            else if (exists.UserId != userId) { throw new Exception("Not your vault player"); }
            return exists;
        }

        internal Vault Create(Vault newVault)
        {
            _vaultRepo.Create(newVault);
            return newVault;
        }


        internal string Delete(int id, string userId)
        {
            var exists = _vaultRepo.GetById(id);
            if (exists.UserId != userId) { throw new Exception("not your vault to delete");}
            _vaultRepo.Delete(id);
            return "Vault has been deleted!";
        }
    }
}