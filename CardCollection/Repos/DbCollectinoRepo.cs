using CardCollection.Entities;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbCollectinoRepo : ICollectionRepo
    {
        CardDbContext _context;

        public DbCollectinoRepo(CardDbContext context)
        {
            _context = context;
        }

        public DbCollectinoRepo() { }

        public List<Card> GetByType(int id, string type)
        {
            User owner = _context.Users.Find(id);
            List<Card> toReturn = _context.Cards.Where(c => c.Owners.Contains(owner) && c.Type == type).ToList();
            return toReturn;
        }

        public List<string> GetAllTypes(int id)
        {
            User owner = _context.Users.Find(id);
            List < Card > cards = _context.Cards.Where(c => c.Owners.Contains(owner)).ToList();
            List<string> types = cards.Where(c => c.Type != "").Select(c => c.Type).Distinct().ToList();
            
            return types;
        }

        public List<Card> GetBySuper(int id, string superType)
        {
            User owner = _context.Users.Find(id);
            List<Card> cards = _context.Cards.Where(c => c.Owners.Contains(owner) && c.supertype == superType).ToList();
            return cards;

        }

        public List<Card> GetByRarity(int id, string rarity)
        {
            User owner = _context.Users.Find(id);
            List<Card> cards = _context.Cards.Where(c => c.Owners.Contains(owner) && c.Rarity == rarity).ToList();
            return cards;
        }

        public List<string> GetAllRarities(int id)
        {
            User owner = _context.Users.Find(id);
            List<Card> cards = _context.Cards.Where(c => c.Owners.Contains(owner)).ToList();
            List<string> rarities = cards.Where(c => c.Rarity != "").Select(c => c.Rarity).Distinct().ToList();

            return rarities;
        }

        public List<string> GetAllSeries(int id)
        {
            User owner = _context.Users.Find(id);
            List<Card> cards = _context.Cards.Where(c => c.Owners.Contains(owner)).ToList();
            List<Sets> sets = new List<Sets>();
            foreach (Card c in cards)
            {
                Sets toAdd = _context.Sets.Single(s => s.Id == c.SetId);
                sets.Add(toAdd);
            }
            List<string> allSeries = sets.Where(s => s.Series != "").Select(s => s.Series).Distinct().ToList();
            return allSeries;
        }

        
    }
}
