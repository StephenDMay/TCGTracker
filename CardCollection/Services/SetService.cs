using CardCollection.Repos;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class SetService : ISetService
    {
        ITCGCardRepo _tcgRepo = new TCGCardRepo();
        ISetRepo _setRepo;

        public SetService()
        {

        }

        public SetService(CardDbContext context)
        {

            _setRepo = new DbSetRepo(context);
        }

        public void AddAllSets()
        {
            _tcgRepo.AddAllSets();
        }

        public List<string> GetAllSeries()
        {
            return _setRepo.GetAllSeries();
        }

        public List<Sets> GetSetsBySeries(string name)
        {
            return _setRepo.GetSetsBySeries(name);
        }

        public Sets GetSetById(string id)
        {
            return _setRepo.GetSetsById(id);
        }
    }
}
