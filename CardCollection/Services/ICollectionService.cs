using CardCollection.Models;
using System.Collections.Generic;

namespace CardCollection.Services
{
    public interface ICollectionService
    {
        List<string> GetAllRarities(int id);
        List<string> GetAllSeries(int id);
        List<string> GetAllTypes(int id);
        List<Card> GetByRarity(int id, string rarity);
        List<Card> GetBySuper(int id, string superType);
        List<Card> GetByType(int id, string type);
    }
}