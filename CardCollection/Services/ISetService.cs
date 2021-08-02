using CardCollection.Models;
using System.Collections.Generic;

namespace CardCollection.Services
{
    public interface ISetService
    {
        void AddAllSets();
        List<string> GetAllSeries();
        Sets GetSetById(string id);
        List<Sets> GetSetsBySeries(string name);
    }
}