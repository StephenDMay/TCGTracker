using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public interface ICardRepo
    {
        Card GetCardById(string id);
        List<Card> GetCardsByType(string type);
        List<Card> GetCardsByRarity(string rarity);
        List<Card> GetCardsByIllustrator(string name);
        List<Card> GetCardsBySet(string set);
        List<string> GetAllSets();
    }
}
