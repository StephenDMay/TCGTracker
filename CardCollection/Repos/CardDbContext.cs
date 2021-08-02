using CardCollection.Entities;
using CardCollection.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace CardCollection.Repos
{
    public class CardDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        //public CardDbContext(DbContextOptions<CardDbContext> options, IConfiguration configuration) : base(options) 
        //{
        //    _configuration = configuration;
        //}

        public CardDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Trade> AvailableTrades { get; set; }

        //public DbSet<Offer> Offers { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Sets> Sets { get; set; }



        //public CardDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //public CardDbContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    //string conn = ConfigurationManager.
        //    // connect to sql server database
        //    options.UseSqlServer(_configuration.GetConnectionString("Db1"));
        //}

    }
}
