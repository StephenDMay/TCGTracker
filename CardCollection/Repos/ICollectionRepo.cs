using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public interface ICollectionRepo
    {
        List<Card> GetByType(int id, string type);
        List<string> GetAllTypes(int id);
        List<Card> GetBySuper(int id, string superType);
        List<Card> GetByRarity(int id, string rarity);
        List<string> GetAllRarities(int id);
        List<string> GetAllSeries(int id);
    }
}
