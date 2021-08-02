using CardCollection.Entities;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos.InMemDao
{
    public class CollectionInMemDao : ICollectionRepo
    {

        private List<User> _users = new List<User>();
        private List<Card> _collection = new List<Card>();
        


        public CollectionInMemDao()
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
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _users.Add(toAdd);

            _collection.Add(Mewtwo);
            _collection.Add(Alakazam);
            _collection.Add(Nidoking);
        }
        public List<string> GetAllRarities(int id)
        {
            List<string> rarities = _collection.Select(c => c.Rarity).Distinct().ToList();
            return rarities;
        }

        public List<string> GetAllSeries(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllTypes(int id)
        {
            List<string> types = _collection.Select(c => c.Type).Distinct().ToList();
            return types;
        }

        public List<Card> GetByRarity(int id, string rarity)
        {
            return _collection.Where(c => c.Rarity == rarity).ToList();
        }

        public List<Card> GetBySuper(int id, string superType)
        {
            return _collection.Where(c => c.supertype == superType).ToList();
        }

        public List<Card> GetByType(int id, string type)
        {
            return _collection.Where(c => c.Type == type).ToList();
        }
    }
}
