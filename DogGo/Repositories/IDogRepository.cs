using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        public List<Dog> GetAllDogs();
        public List<Dog> GetDogsByOwnerId(int ownerId);
        public Dog GetDogById(int id);
        public void AddDog(Dog dog);
        public void UpdateDog(Dog dog);
        public void DeleteDog(int dogId);
    }
}
