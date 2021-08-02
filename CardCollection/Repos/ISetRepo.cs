using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface ISetRepo
    {
        List<string> GetAllSeries();
        List<Sets> GetSetsBySeries(string name);
        Sets GetSetsById(string id);
    }
}
