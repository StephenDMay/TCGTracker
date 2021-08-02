using CardCollection.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using CardCollection.Entities;
using System.Collections.Generic;
using CardCollection.Models;
using System.Linq;

namespace CardCollectionTests
{
    public class CollectionRepoTests
    {
        DbCollectinoRepo _collRepo;
        DbUserRepo _userRepo;
        ServiceCollection _services = new ServiceCollection();

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CardDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDB"));

            CardDbContext con = new CardDbContext(builder.Options);
            _collRepo = new DbCollectinoRepo(con);
            _userRepo = new DbUserRepo(con);

            con.Users.RemoveRange(con.Users);


            
            con.SaveChanges();
            //_services.AddDbContext<CardDbContext>(options =>
            //    options.UseSqlServer(config.GetConnectionString("TestDB")));
            //_services.AddScoped<ICollectionRepo, DbCollectinoRepo>();
        }

        [Test]
        public void TestGetByType()
        {
            User toAdd = new User
            {
                FirstName = "New",
                LastName = "User",
                Username = "Test",
            };

            _userRepo.Create(toAdd, "Test");
            List<User> all = _userRepo.GetAll().ToList();
            int id = all[0].Id;


            Card card = new Card
            {
                Id = "base1-1",
                Name = "Alakazam",
                Type = "Psychic",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "1",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/1.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 80,
                price = decimal.Parse("0.38")
            };

            _userRepo.AddToCollection(id, card.Id);

            List<Card> cards = _collRepo.GetByType(id, "Psychic");

            Assert.AreEqual(1, cards.Count);
            Assert.AreEqual("base1-1", cards[0].Id);
            Assert.AreEqual("Alakazam", cards[0].Name);
            Assert.AreEqual("Psychic", cards[0].Type);
            Assert.AreEqual("base1", cards[0].SetId);
            Assert.AreEqual("Rare Holo", cards[0].Rarity);
            Assert.AreEqual("1", cards[0].NumberInSet);
            Assert.AreEqual("Ken Sugimori", cards[0].Illustrator);
            Assert.AreEqual("https://images.pokemontcg.io/base1/1.png", cards[0].Image);
            Assert.AreEqual(1999, cards[0].ReleaseYear);
            Assert.AreEqual("Pokémon", cards[0].supertype);
            Assert.AreEqual(80, cards[0].hp);
            Assert.AreEqual(decimal.Parse("0.38"), cards[0].price);
        }

        [Test]
        public void TestGetBySuper()
        {
            User toAdd = new User
            {
                FirstName = "New",
                LastName = "User",
                Username = "Test",
            };

            _userRepo.Create(toAdd, "Test");
            List<User> all = _userRepo.GetAll().ToList();
            int id = all[0].Id;


            Card card = new Card
            {
                Id = "base1-1",
                Name = "Alakazam",
                Type = "Psychic",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "1",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/1.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 80,
                price = decimal.Parse("0.38")
            };

            _userRepo.AddToCollection(id, card.Id);

            List<Card> cards = _collRepo.GetBySuper(id, "Pokémon");

            Assert.AreEqual(1, cards.Count);
            Assert.AreEqual("base1-1", cards[0].Id);
            Assert.AreEqual("Alakazam", cards[0].Name);
            Assert.AreEqual("Psychic", cards[0].Type);
            Assert.AreEqual("base1", cards[0].SetId);
            Assert.AreEqual("Rare Holo", cards[0].Rarity);
            Assert.AreEqual("1", cards[0].NumberInSet);
            Assert.AreEqual("Ken Sugimori", cards[0].Illustrator);
            Assert.AreEqual("https://images.pokemontcg.io/base1/1.png", cards[0].Image);
            Assert.AreEqual(1999, cards[0].ReleaseYear);
            Assert.AreEqual("Pokémon", cards[0].supertype);
            Assert.AreEqual(80, cards[0].hp);
            Assert.AreEqual(decimal.Parse("0.38"), cards[0].price);
        }

        [Test]
        public void TestGetByRarity()
        {
            User toAdd = new User
            {
                FirstName = "New",
                LastName = "User",
                Username = "Test",
            };

            _userRepo.Create(toAdd, "Test");
            List<User> all = _userRepo.GetAll().ToList();
            int id = all[0].Id;


            Card card = new Card
            {
                Id = "base1-1",
                Name = "Alakazam",
                Type = "Psychic",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "1",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/1.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 80,
                price = decimal.Parse("0.38")
            };

            _userRepo.AddToCollection(id, card.Id);

            List<Card> cards = _collRepo.GetByRarity(id, "Rare Holo");

            Assert.AreEqual(1, cards.Count);
            Assert.AreEqual("base1-1", cards[0].Id);
            Assert.AreEqual("Alakazam", cards[0].Name);
            Assert.AreEqual("Psychic", cards[0].Type);
            Assert.AreEqual("base1", cards[0].SetId);
            Assert.AreEqual("Rare Holo", cards[0].Rarity);
            Assert.AreEqual("1", cards[0].NumberInSet);
            Assert.AreEqual("Ken Sugimori", cards[0].Illustrator);
            Assert.AreEqual("https://images.pokemontcg.io/base1/1.png", cards[0].Image);
            Assert.AreEqual(1999, cards[0].ReleaseYear);
            Assert.AreEqual("Pokémon", cards[0].supertype);
            Assert.AreEqual(80, cards[0].hp);
            Assert.AreEqual(decimal.Parse("0.38"), cards[0].price);
        }

        [Test]
        public void TestGetAllRarites()
        {
            User toAdd = new User
            {
                FirstName = "New",
                LastName = "User",
                Username = "Test",
            };

            _userRepo.Create(toAdd, "Test");
            List<User> all = _userRepo.GetAll().ToList();
            int id = all[0].Id;


            Card card = new Card
            {
                Id = "base1-1",
                Name = "Alakazam",
                Type = "Psychic",
                SetId = "base1",
                Rarity = "Rare Holo",
                NumberInSet = "1",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/1.png",
                ReleaseYear = 1999,
                supertype = "Pokémon",
                hp = 80,
                price = decimal.Parse("0.38")
            };

            _userRepo.AddToCollection(id, card.Id);

            List<Card> cards = _collRepo.GetByRarity(id, "Rare Holo");

            List<string> rarities = _collRepo.GetAllRarities(id);

            Assert.AreEqual(1, rarities.Count);
            Assert.AreEqual("Rare Holo", rarities[0]);
        }

      
    }
}