//using CardCollection.Models;
//using CardCollection.Repos;
//using CardCollection.Services;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CardCollection.Controllers
//{
//    [ApiController]
//    [Route("Trades/{id}/Offers")]
//    public class OfferController : Controller
//    {

//        OfferService _offerService = new OfferService();

//        public OfferController(CardDbContext context)
//        {
//            _offerService = new OfferService(context);
//        }

//        [HttpPost("Add/{userId}")]
//        public IActionResult AddOffer(int id, int userId, Offer toAdd)
//        {
//            Offer toReturn = _offerService.AddOffer(id, userId, toAdd);
//            return Accepted(toReturn);
//        }

//        [HttpGet]
//        public IActionResult GetOffersByTrade(int id)
//        {
//            List<Offer> offers = _offerService.GetOffers(id);
//            return Accepted(offers);
//        }
//    }
//}
