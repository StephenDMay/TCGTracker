using CardCollection.Models;
using System.Collections.Generic;

namespace CardCollection.Services
{
    public interface IRequestService
    {
        Request AddRequest(int id, List<Card> toAdd);
        List<Card> GetReqByTrade(int id);
    }
}