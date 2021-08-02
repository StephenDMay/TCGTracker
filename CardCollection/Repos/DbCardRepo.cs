using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbCardRepo : ICardRepo
    {

        CardDbContext _context;

        public DbCardRepo()
        {
        }

        public DbCardRepo(CardDbContext context)
        {
            _context = context;

        }

        public List<string> GetAllSets()
        {
            List<string> toReturn = _context.Cards.Select(c => c.SetId).Distinct().ToList();
            return toReturn;
        }

        public Card GetCardById(string id)
        {
            Card toReturn = _context.Cards.Find(id);
            return toReturn;
        }

        public List<Card> GetCardsByIllustrator(string name)
        {
            List<Card> toReturn = _context.Cards.Where(c => c.Illustrator == name).ToList();
            return toReturn;
        }

        public List<Card> GetCardsByRarity(string rarity)
        {
            List<Card> toReturn = _context.Cards.Where(c => c.Rarity == rarity).ToList();
            return toReturn;
        }

        public List<Card> GetCardsBySet(string set)
        {

            List<Card> toReturn = _context.Cards.Where(c => c.SetId == set).ToList();
            return toReturn;

        }

        public List<Card> GetCardsByType(string type)
        {
            List<Card> toReturn = _context.Cards.Where(c => c.Type == type).ToList();
            return toReturn;
        }
    }
}
