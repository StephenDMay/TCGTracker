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
    [Route("/Collection")]
    public class CollectionController : Controller
    {

        ICollectionService _service;
        ISetService _setService;

        public CollectionController(ICollectionService service, ISetService setService)
        {
            _service = service;
            _setService = setService;
        }

        [HttpGet("{id}/{type}")]
        public IActionResult GetCollectionByType(int id, string type)
        {
            List<Card> cards = _service.GetByType(id, type);
            return Accepted(cards);
        }

        [HttpGet("{id}/allTypes")]
        public IActionResult GetAllTypes(int id)
        {
            List<string> types = _service.GetAllTypes(id);
            return Accepted(types);
        }

        [HttpGet("{id}/superType/{superType}")]
        public IActionResult GetCollectionBySuper(int id, string superType)
        {
            List<Card> cards = _service.GetBySuper(id, superType);
            return Accepted(cards);
        }

        [HttpGet("{id}/rarity/{rarity}")]
        public IActionResult GetCollectionByRarity(int id, string rarity)
        {
            List<Card> cards = _service.GetByRarity(id, rarity);
            return Accepted(cards);
        }

        [HttpGet("{id}/allRarities")]
        public IActionResult GetAllRarities(int id)
        {
            List<string> rarities = _service.GetAllRarities(id);
            return Accepted(rarities);
        }

        [HttpGet("{id}/allSeries")]
        public IActionResult GetAllSeries(int id)
        {
            List<string> allSeries = _service.GetAllSeries(id);
            return Accepted(allSeries);
        }
    }
}
