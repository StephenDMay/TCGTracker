using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class Request
    {

        public int Id { get; set; }

        public Trade trade { get; set; }

        public List<Card> RequestedCards { get; set; } = new List<Card>();
    }
}
