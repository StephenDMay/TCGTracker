using CardCollection.Entities;
using CardCollection.Models;
using System.Collections.Generic;

namespace CardCollection.Services
{
    public interface ITradeService
    {
        Trade AddTrade(int id, Trade toAdd);
        List<Trade> GetAll();
        Trade GetById(int id);
        List<Card> getCardsByTradeId(int id);
        User GetTradeUser(int tradeId);
        string RemoveTrade(int id);
    }
}