using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class RequestService : IRequestService
    {

        IRequestRepo _requestRepo;

        public RequestService()
        {

        }

        public RequestService(CardDbContext context)
        {
            _requestRepo = new DbRequestRepo(context);
        }

        public Request AddRequest(int id, List<Card> toAdd)
        {
            return _requestRepo.AddRequest(id, toAdd);
        }

        public List<Card> GetReqByTrade(int id)
        {
            return _requestRepo.GetReqByTrade(id);
        }
    }
}
