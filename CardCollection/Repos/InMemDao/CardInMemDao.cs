using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos.InMemDao
{
    public class CardInMemDao : ICardRepo
    {

        private List<Card> _allCards = new List<Card>();


        public CardInMemDao()
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

            _allCards.Add(Mewtwo);
            _allCards.Add(Alakazam);
            _allCards.Add(Nidoking);
        }
        public List<string> GetAllSets()
        {
            return _allCards.Select(c => c.SetId).Distinct().ToList();
        }

        public Card GetCardById(string id)
        {
            return _allCards.Single(c => c.Id == id);
        }

        public List<Card> GetCardsByIllustrator(string name)
        {
            return _allCards.Where(c => c.Illustrator == name).ToList();
        }

        public List<Card> GetCardsByRarity(string rarity)
        {
            return _allCards.Where(c => c.Rarity == rarity).ToList();
        }

        public List<Card> GetCardsBySet(string set)
        {
            return _allCards.Where(c => c.SetId == set).ToList();
        }

        public List<Card> GetCardsByType(string type)
        {
            return _allCards.Where(c => c.Type == type).ToList();
        }
    }
}
