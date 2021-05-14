using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IOwnerRepository
    {
        public List<Owner> GetAllOwners();
        public Owner GetOwnerById(int id);
        public Owner GetOwnerByEmail(string email);
        public void AddOwner(Owner owner);
        public void UpdateOwner(Owner owner);
        public void DeleteOwner(int ownerId);
    }
}
