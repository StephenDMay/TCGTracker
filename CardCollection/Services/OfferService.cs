//using CardCollection.Models;
//using CardCollection.Repos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CardCollection.Services
//{
//    public class OfferService
//    {
//        IOfferRepo _offerRepo;

//        public OfferService()
//        {
//        }

//        public OfferService(CardDbContext context)
//        {
//            _offerRepo = new DbOfferRepo(context);
//        }

//        internal Offer AddOffer(int id, int userId, Offer toAdd)
//        {
//            return _offerRepo.AddOffer(id, userId, toAdd);
//        }

//        internal List<Offer> GetOffers(int id)
//        {
//            return _offerRepo.GetOffers(id);
//        }
//    }
//}
