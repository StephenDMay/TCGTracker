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
    [Route("/Trades/Requests")]
    public class RequestController : Controller
    {
        IRequestService _requestService;

        public RequestController(IRequestService service)
        {
            _requestService = service;
        }

        [HttpPost("Add/{id}")]
        public IActionResult AddRequest(int id, List<Card> toAdd)
        {
            Request req = _requestService.AddRequest(id, toAdd);
            return Accepted(req);
        }

        [HttpGet("{id}")]
        public IActionResult GetRequestByTradeId(int id)
        {
            List<Card> req = _requestService.GetReqByTrade(id);
            return Accepted(req);
        }

        
    }
}
