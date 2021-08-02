//using CardCollection.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CardCollection.Repos
//{
//    public class DbOfferRepo : IOfferRepo
//    {
//        CardDbContext _context;

//        public DbOfferRepo(CardDbContext context)
//        {
//            _context = context;
//        }

//        public Offer AddOffer(int id, int userId, Offer toAdd)
//        {
//            Offer offer = new Offer()
//            {
//                user = _context.Users.Single(u => u.Id == userId),
//                trade = _context.AvailableTrades.Single(t => t.Id == id),
//                OfferedCards = _context.Cards.Where(c => toAdd.OfferedCards.Contains(c)).ToList()
//            };

//            _context.Offers.Add(offer);

//            foreach(Card c in offer.OfferedCards)
//            {
//                _context.Cards.Find(c.Id).Offers.Add(offer);
//            }

//            _context.SaveChanges();
//            return offer;
                
//        }

//        public List<Offer> GetOffers(int id)
//        {
//            List<Offer> offers = _context.Offers.Where(o => o.trade.Id == id).ToList();

//            foreach(Offer o in offers)
//            {
//                o.OfferedCards = _context.Cards.Where(c => c.Offers.Contains(o)).ToList();
//                o.trade = _context.AvailableTrades.Find(id);
//            }

//            return offers;
//        }
//    }
//}
