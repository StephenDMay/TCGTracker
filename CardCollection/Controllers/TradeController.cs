using CardCollection.Entities;
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
    [Route("/Trades")]
    public class TradeController : Controller
    {

        private ITradeService _tradeService;

        public TradeController(ITradeService service)
        {
            _tradeService = service;
        }

        [HttpPost("Add/{id}")]
        public IActionResult AddTrade(int id, Trade toAdd)
        {
            Trade toReturn = _tradeService.AddTrade(id, toAdd);
            return Accepted(toReturn);
        }

        [HttpGet]
        public IActionResult GetAllTrades()
        {
            
            List<Trade> all = _tradeService.GetAll();
            return Accepted(all);
        }

        [HttpGet("{id}")]
        public IActionResult GetTradeById(int id)
        {
            Trade toReturn = _tradeService.GetById(id);
            return Accepted(toReturn);
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult RemoveTradeById(int id)
        {
            string response = _tradeService.RemoveTrade(id);
            return Accepted(response);
        }

        [HttpGet("Cards/{id}")]
        public IActionResult GetCardsByTradeId(int id)
        {
            List < Card > cards = _tradeService.getCardsByTradeId(id);
            return Accepted(cards);
        }

        [HttpGet("{tradeId}/user")]
        public IActionResult GetTradeUser(int tradeId)
        {
            User user = _tradeService.GetTradeUser(tradeId);
            return Accepted(user);
        }

       

        //TODO: GET TRADE BY USER ID
    }


}
