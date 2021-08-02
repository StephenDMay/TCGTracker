using CardCollection.Exceptions;
using CardCollection.Models;
using CardCollection.Repos.InMemDao;
using CardCollection.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardCollectionTests.ServiceTests
{
    class CardServiceTests
    {

        private CardInMemDao _dao;
        CardService _service;

        [SetUp]
        public void Setup()
        {
            _dao = new CardInMemDao();
            _service = new CardService(_dao);
        }

        [TestCase("base1-1")]
        [TestCase(null)]
        public void TestGetCardById(string id)
        {
            if (id == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetCardById(id));
            }
            else
            {
                Card toCheck = _service.GetCardById(id);
                Assert.AreEqual("base1-1", toCheck.Id);

            }
            
        }

        [TestCase("Psychic")]
        [TestCase(null)]
        public void TestGetCardsByNullType(string type)
        {
            if (type == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetCardsByType(type));
            }
            else
            {
                List<Card> cards = _service.GetCardsByType(type);

                Assert.AreEqual(2, cards.Count);
            }
            
        }

        [TestCase("Rare Holo")]
        [TestCase(null)]
        public void TestGetCardsByNullRarity(string rarity)
        {
            if (rarity == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetCardsByRarity(rarity));
            }
            else
            {
                List<Card> cards = _service.GetCardsByRarity(rarity);

                Assert.AreEqual(3, cards.Count);
            }

        }

        [TestCase("Ken Sugimori")]
        [TestCase(null)]
        public void TestGetCardsByNullIllustrator(string ill)
        {
            if (ill == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetCardsByIllustrator(ill));
            }
            else
            {
                List<Card> cards = _service.GetCardsByIllustrator(ill);

                Assert.AreEqual(3, cards.Count);
            }
            
        }

        [TestCase("base1")]
        [TestCase(null)]
        public void TestGetCardsByNullSet(string set)
        {
            if (set == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetCardsBySet(set));
            }
            else
            {
                List<Card> cards = _service.GetCardsBySet(set);

                Assert.AreEqual(3, cards.Count);
            }
            
        }
    }
}
