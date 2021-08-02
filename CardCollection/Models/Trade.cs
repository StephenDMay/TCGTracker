
using CardCollection.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    
    public class Trade 
    {

        public int Id { get; set; }

        public User user { get; set; }

        public List<Card> CardsOffered { get; set; } = new List<Card>();

        public Trade()
        {

        }
    }
}
