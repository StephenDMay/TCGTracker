using CardCollection.Models;
using CardCollection.Repos;
using CardCollection.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Controllers
{


    [ApiController]
    [Route("/Cards")]
    public class CardController : Controller
    {
        CardService _cardService;

        public CardController(CardDbContext context)
        {
            _cardService = new CardService(context);
        }



        [HttpPost("AddAll")]
        public IActionResult AddAll()
        {
            _cardService.AddAllCards();
            return Accepted();
        }

        [HttpGet("{id}")]
        public IActionResult GetCardById(string id)
        {
            Card card = _cardService.GetCardById(id);
            return Accepted(card);
        }

        [HttpGet("Type/{type}")]
        public IActionResult GetCardsByType(string type)
        {
            List<Card> cards = _cardService.GetCardsByType(type);
            return Accepted(cards);
        }

        [HttpGet("Set/{setId}")]
        public IActionResult GetCardsBySet(string setId)
        {
            List<Card> cards = _cardService.GetCardsBySet(setId);
            return Accepted(cards);
        }

        [HttpGet("Rarity/{rarity}")]
        public IActionResult GetCardsByRarity(string rarity)
        {
            List<Card> cards = _cardService.GetCardsByRarity(rarity);
            return Accepted(cards);
        }

        [HttpGet("Illustrator/{name}")]
        public IActionResult GetCardsByIllustrator(string name)
        {
            List<Card> cards = _cardService.GetCardsByIllustrator(name);
            return Accepted(cards);
        }

        [HttpGet("allSets")]
        public IActionResult GetAllSets()
        {
            List<string> sets = _cardService.GetAllSets();
            return Accepted(sets);
        }


    }
}
