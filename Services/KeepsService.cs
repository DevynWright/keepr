using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }
        internal Keep GetById(int id)
        {
            var exists = _repo.GetById(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            return exists;
        }

        internal Keep Create(Keep newKeep)
        {
            _repo.Create(newKeep);
            return newKeep;
        }


        internal string Delete(int id)
        {
            var exists = _repo.GetById(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            _repo.Delete(id);
            return "Keep has been deleted!";
        }

        internal object Edit(Keep update)
        {
            var exists = _repo.GetById(update.Id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            _repo.Edit(update);
            return update;
        }
    }
}