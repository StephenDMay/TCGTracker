using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CardCollection.Models
{
    public class Sets
    {
        [Column("Id")]
        [Required]
        public string Id { get; set; }

        public string Series { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        List<Card> cardsInSet { get; set; } = new List<Card>();
    }
}
