using CardCollection.Entities;
using CardCollection.Models;
using CardCollection.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Services
{
    public class TradeService : ITradeService
    {

        ITradeRepo _tradeRepo;

        public TradeService()
        {
        }

        public TradeService(CardDbContext context)
        {
            _tradeRepo = new DbTradeRepo(context);
        }

        public Trade AddTrade(int id, Trade toAdd)
        {
            return _tradeRepo.AddTrade(id, toAdd);
        }

        public List<Trade> GetAll()
        {
            return _tradeRepo.GetAll();
        }

        public Trade GetById(int id)
        {
            return _tradeRepo.GetById(id);
        }

        public string RemoveTrade(int id)
        {
            return _tradeRepo.RemoveTrade(id);
        }

        public List<Card> getCardsByTradeId(int id)
        {
            return _tradeRepo.GetCardsByTradeId(id);
        }

        public User GetTradeUser(int tradeId)
        {
            return _tradeRepo.GetTradeUser(tradeId);
        }
    }
}
