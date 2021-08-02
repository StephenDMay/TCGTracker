using CardCollection.Entities;
using CardCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    interface ITradeRepo
    {
        Trade AddTrade(int id, Trade toAdd);
        List<Trade> GetAll();
        Trade GetById(int id);
        string RemoveTrade(int id);
        List<Card> GetCardsByTradeId(int id);
        User GetTradeUser(int tradeId);
    }
}
