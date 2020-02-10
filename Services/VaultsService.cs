using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> Get()
        {
            return _repo.Get();
        }
        internal Vault GetById(int id)
        {
            var exists = _repo.GetById(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            return exists;
        }

        internal Vault Create(Vault newVault)
        {
            _repo.Create(newVault);
            return newVault;
        }


        internal string Delete(int id)
        {
            var exists = _repo.GetById(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            _repo.Delete(id);
            return "Vault has been deleted!";
        }

        internal object Edit(Vault update)
        {
            var exists = _repo.GetById(update.Id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            _repo.Edit(update);
            return update;
        }
    }
}