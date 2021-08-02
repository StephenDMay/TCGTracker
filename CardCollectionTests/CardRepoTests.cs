using CardCollection.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using CardCollection.Entities;
using System.Collections.Generic;
using System.Linq;
using CardCollection.Models;

namespace CardCollectionTests
{
    class CardRepoTests
    {

        DbCardRepo _repo;
        ServiceCollection _service = new ServiceCollection();



        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CardDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDB"));

            CardDbContext conn = new CardDbContext(builder.Options);
            _repo = new DbCardRepo(conn);
        }

        [Test]
        public void TestGetAllSets()
        {
            List<string> sets = _repo.GetAllSets();

            Assert.AreEqual(123, sets.Count);
        }

        [Test]
        public void TestGetCardById()
        {
            Card toCheck = _repo.GetCardById("base1-75");

            Assert.AreEqual("base1-75", toCheck.Id);
            Assert.AreEqual("Lass", toCheck.Name);
            Assert.AreEqual("", toCheck.Type);
            Assert.AreEqual("base1", toCheck.SetId);
            Assert.AreEqual("Rare", toCheck.Rarity);
            Assert.AreEqual("75", toCheck.NumberInSet);
            Assert.AreEqual("Ken Sugimori", toCheck.Illustrator);
            Assert.AreEqual("https://images.pokemontcg.io/base1/75.png", toCheck.Image);
            Assert.AreEqual(1999, toCheck.ReleaseYear);
            Assert.AreEqual("Trainer", toCheck.supertype);
            Assert.AreEqual(0, toCheck.hp);
            Assert.AreEqual(decimal.Parse("0.38"), toCheck.price);
        }

        [Test]
        public void TestGetCardsByIllustrator()
        {
            List<Card> cards = _repo.GetCardsByIllustrator("Ken Sugimori");

            Assert.AreEqual(1081, cards.Count);
        }

        [Test]
        public void TestGetCardsByRarity()
        {
            List<Card> cards = _repo.GetCardsByRarity("Rare");

            Assert.AreEqual(2030, cards.Count);
        }

        [Test]
        public void TestGetCardsBySet()
        {
            List<Card> cards = _repo.GetCardsBySet("base1");

            Assert.AreEqual(102, cards.Count);
        }

        [Test]
        public void TestGetCardsByType()
        {
            List<Card> cards = _repo.GetCardsByType("Water");

            Assert.AreEqual(1694, cards.Count);
        }
    }
}
