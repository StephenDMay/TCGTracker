using CardCollection.Entities;
using CardCollection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class DbTradeRepo : ITradeRepo
    {

        CardDbContext _context;

        public DbTradeRepo(CardDbContext context)
        {
            _context = context;
        }

        public Trade AddTrade(int id, Trade trade)
        {
            Trade toAdd = trade;
            User user = _context.Users.Find(id);
            
            toAdd.user = user;
            user.Trades.Add(toAdd);

            _context.AvailableTrades.Add(toAdd);

            foreach (Card c in toAdd.CardsOffered)
            {
                _context.Attach(c);
                c.TradeOffers.Add(toAdd);
            }

            _context.SaveChanges();
            return toAdd;
        }

        public List<Trade> GetAll()
        {
            // Get all Trades
            List<Trade> all = _context.AvailableTrades.OrderBy(c => c.Id).ToList();
            foreach(Trade t in all)
            {
                t.user = _context.Users.Single(u => u.Trades.Contains(t));
                IEnumerable<Card> toAdd = _context.Cards.Where(c => c.TradeOffers.Contains(t));
                foreach(Card c in toAdd)
                {
                    t.CardsOffered.Add(c);
                }


                
            }

            return all;

        }

        public Trade GetById(int id)
        {
            Trade toReturn = _context.AvailableTrades.Find(id);
            
            toReturn.CardsOffered = _context.Cards.Where(c => c.TradeOffers.Contains(toReturn)).ToList();
            toReturn.user = _context.Users.Single(u => u.Trades.Contains(toReturn));

            return toReturn;
        }

        public List<Card> GetCardsByTradeId(int id)
        {
            Trade trade = _context.AvailableTrades.Find(id);
            List<Card> cards = _context.Cards.Where(c => c.TradeOffers.Contains(trade)).ToList();

            return cards;
        }

        public User GetTradeUser(int id)
        {
            Trade trade = _context.AvailableTrades.Find(id);
            User user = _context.Users.Single(u => u.Trades.Contains(trade));
            return user;
        }

        public string RemoveTrade(int id)
        {
            Trade toDelete = _context.AvailableTrades.Find(id);
            Request req = _context.Requests.SingleOrDefault(r => r.trade.Id == toDelete.Id);
            List<Card> reqCards = _context.Cards.Where(c => c.Requests.Contains(req)).ToList();

            foreach (Card c in reqCards)
            {
                c.Requests.Remove(req);
            }
            if (req != null)
            {
                _context.Attach(req);
                _context.Remove(req);
            }
            
            _context.Attach(toDelete);
            _context.Remove(toDelete);


            _context.SaveChanges();

            return $"Trade {id} removed.";
        }
    }
}
