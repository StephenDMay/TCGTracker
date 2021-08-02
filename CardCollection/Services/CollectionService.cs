using CardCollection.Exceptions;
using CardCollection.Models;
using CardCollection.Repos;
using CardCollection.Repos.InMemDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class CollectionService : ICollectionService
    {
        ICollectionRepo _repo;

        public CollectionService()
        {
        }

        public CollectionService(ICollectionRepo repo)
        {
            _repo = repo;
        }

        //ADD , ICollectionRepo collRepo to constructor params
        public CollectionService(CardDbContext context)
        {
            _repo = new DbCollectinoRepo(context);

            //_repo = collRepo;
        }

        public List<Card> GetByType(int id, string type)
        {
            if (type == null)
            {
                throw new NullArgumentException("Can not find cards with null type.");
            }
            else
            {
                return _repo.GetByType(id, type);
            }
            
        }

        public List<string> GetAllTypes(int id)
        {
            if (id <= 0)
            {
                throw new NoUserFoundException("Cannot find user with id of " + id);
            }
            else
            {
                return _repo.GetAllTypes(id);
            }
            
        }

        public List<Card> GetBySuper(int id, string superType)
        {
            if (superType == null)
            {
                throw new NullArgumentException("Can not find cards with null super type.");
            }
            else
            {
                return _repo.GetBySuper(id, superType);
            }
            
        }

        public List<Card> GetByRarity(int id, string rarity)
        {

            if (rarity == null)
            {
                throw new NullArgumentException("Can not find cards with null rarity.");
            }
            else return _repo.GetByRarity(id, rarity);
        }

        public List<string> GetAllRarities(int id)
        {
            if (id <= 0)
            {
                throw new NoUserFoundException("Cannot find user with id of " + id);
            }
            else return _repo.GetAllRarities(id);
        }

        public List<string> GetAllSeries(int id)
        {
            if (id <= 0)
            {
                throw new NoUserFoundException("Cannot find user with id of " + id);
            }
            else return _repo.GetAllSeries(id);
        }
    }
}
