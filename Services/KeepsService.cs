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
        public IEnumerable<Keep> GetMyKeeps(string userId)
        {
            return _repo.GetMyKeeps(userId);
        }
        internal Keep GetById(int id, string userId)
        {
            var exists = _repo.GetById(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            else if (exists.IsPrivate == true)
            {
                if(exists.UserId != userId){ throw new Exception("not your keep player");}
                exists.Views += 1;
                _repo.Edit(exists);
                return exists;
            }
            exists.Views += 1;
            _repo.Edit(exists);
            return exists;
        }

        internal Keep Create(Keep newKeep)
        {
            _repo.Create(newKeep);
            return newKeep;
        }


        internal string Delete(int id, string userId)
        {
            var exists = _repo.GetById(id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            else if (exists.UserId != userId){ throw new Exception("Not yours to delete player");}
            _repo.Delete(id);
            return "Keep has been deleted!";
        }


        internal object Edit(Keep update, string userId)
        {
            var exists = _repo.GetById(update.Id);
            if(exists == null) { throw new Exception("Item Does not Exist");}
            else if (exists.UserId != userId){ throw new Exception("Not yours to edit player");}
            _repo.Edit(update);
            return update;
        }
    }
}