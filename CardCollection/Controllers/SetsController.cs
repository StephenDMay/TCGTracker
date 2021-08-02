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
    [Route("/Sets")]
    public class SetsController : Controller
    {


        ISetService _service;


        public SetsController(ISetService service)
        {
            _service = service;
        }

        [HttpPost("AddAll")]
        public IActionResult AddAll()
        {
            _service.AddAllSets();
            return Accepted();
        }

        [HttpGet("Series")]
        public IActionResult GetSeries()
        {
            List<string> series = _service.GetAllSeries();
            return Accepted(series);
        }

        [HttpGet("{name}")]
        public IActionResult GetSetsBySeries(string name)
        {
            List<Sets> sets = _service.GetSetsBySeries(name);
            return Accepted(sets);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetSetById(string id)
        {
            Sets set = _service.GetSetById(id);
            return Accepted(set);
        }
    }
}
