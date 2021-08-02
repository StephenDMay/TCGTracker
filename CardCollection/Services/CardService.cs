using CardCollection.Exceptions;
using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    
    public class CardService
    {

        ITCGCardRepo _tcgRepo = new TCGCardRepo();
        public ICardRepo _cardRepo;

        public CardService(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }

        public CardService(CardDbContext context)
        {
            
            _cardRepo = new DbCardRepo(context);
        }

        

        public string AddAllCards()
        {
            return _tcgRepo.AddAll();
        }

        public Card GetCardById(string id)
        {

            if (id == null)
            {
                throw new NullArgumentException("Can not find card with null Id.");
            }
            else
            {
                return _cardRepo.GetCardById(id);
            }
            
        }

        public List<Card> GetCardsByType(string type)
        {
            if (type == null)
            {
                throw new NullArgumentException("Can not find cards with null Type.");
            }
            else
            {
                return _cardRepo.GetCardsByType(type);
            }
        }

        public List<Card> GetCardsByRarity(string rarity)
        {
            if (rarity == null)
            {
                throw new NullArgumentException("Can not find cards with null Rarity.");
            }
            else
            {
                return _cardRepo.GetCardsByRarity(rarity);
            }
        }

        public List<Card> GetCardsByIllustrator(string name)
        {
            if (name == null)
            {
                throw new NullArgumentException("Can not find cards with null Illustrator.");
            }
            else
            {
                return _cardRepo.GetCardsByIllustrator(name);
            }
        }

        public List<Card> GetCardsBySet(string set)
        {
            if (set == null)
            {
                throw new NullArgumentException("Can not find cards with null Set.");
            }
            else
            {
                return _cardRepo.GetCardsBySet(set);
            }
        }

        public List<string> GetAllSets()
        {
            return _cardRepo.GetAllSets();
        }
    }
}
