using CardCollection.Entities;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos.InMemDao
{
    public class UserInMemDao : IUserRepo
    {

        private List<User> _users = new List<User>();
        private List<Card> _collection = new List<Card>();
        private List<Card> _allCards = new List<Card>();


        public UserInMemDao()
        {
            Card Alakazam = new Card
            {
                Id = "base1-1",
                Name = "Alakazam",
                Type = "Psychic",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "1",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/1.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 80,
                price = decimal.Parse("0.38")
            };

            Card Mewtwo = new Card
            {
                Id = "base1-10",
                Name = "Mewtwo",
                Type = "Psychic",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "10",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/10.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 60,
                price = decimal.Parse("0.38")
            };

            Card Nidoking = new Card
            {
                Id = "base1-11",
                Name = "Nidoking",
                Type = "Grass",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "11",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/11.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 90,
                price = decimal.Parse("0.38")
            };

            User toAdd = new User
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "Test2",
                Username = "Test3",
            };

            _users.Add(toAdd);

            _allCards.Add(Mewtwo);
            _allCards.Add(Alakazam);
            _allCards.Add(Nidoking);

            _collection.Add(Nidoking);
        }

        

        public int AddToCollection(int id, string cardId)
        {
            _collection.Add(_allCards.Single(c => c.Id == cardId));
            return _collection.Count;
        }

        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User Create(User user, string password)
        {
            
            User toAdd = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
            };

            _users.Add(toAdd);
            return toAdd;
        }

        public void Delete(int id)
        {
            
            User toRemove = _users.Single(u => u.Id == id);
            _users.Remove(toRemove);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            if(_users.Single(u => u.Id == id) == null)
            {
                return null;
            }
            else
            {
                return _users.Single(u => u.Id == id);
            }
            
        }

        public int GetSetCount(int id, string setId)
        {
            return _collection.Where(c => c.SetId == setId).ToList().Count;
        }

        public int GetSetTotal(int id, string setId)
        {
            return _allCards.Where(c => c.SetId == setId).ToList().Count;
        }

        public List<Card> GetUserCollection(int id)
        {
            return _collection;
        }

        public string RemoveFromCollection(int id, string cardId)
        {
            Card toRemove = _allCards.Single(c => c.Id == cardId);
            if(_collection.Contains(toRemove))
            {
                _collection.Remove(toRemove);
                return cardId;
            }
            else
            {
                return "Card not found";
            }
            
        }

        public void Update(User userParam, string password)
        {
            throw new NotImplementedException();
        }
    }
}
