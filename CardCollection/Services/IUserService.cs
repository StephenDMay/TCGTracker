using CardCollection.Entities;
using CardCollection.Models;
using System.Collections.Generic;

namespace CardCollection.Services
{
    public interface IUserService
    {
        void AddToCollection(int id, string cardId);
        User Authenticate(string username, string password);
        User Create(User user, string password);
        void Delete(int id);
        IEnumerable<User> GetAll();
        User GetById(int id);
        int GetSetCount(int id, string setId);
        int GetSetTotal(int id, string setId);
        List<Card> GetUserCollection(int id);
        string RemoveFromCollection(int id, string cardId);
        void Update(User userParam, string password = null);
    }
}