using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbSetRepo : ISetRepo
    {

        CardDbContext _context;
        public DbSetRepo()
        {

        }

        public DbSetRepo(CardDbContext context)
        {
            _context = context;
        }

        public List<string> GetAllSeries()
        {
            List<string> toReturn = _context.Sets.Select(s => s.Series).Distinct().ToList();
            return toReturn;
        }

        public Sets GetSetsById(string id)
        {
            Sets set = _context.Sets.Find(id);
            return set;
        }

        public List<Sets> GetSetsBySeries(string name)
        {
            List<Sets> toReturn = _context.Sets.Where(s => s.Series == name).ToList();
            return toReturn;
        }
    }
}
