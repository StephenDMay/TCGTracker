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
    class CollectionServiceTests
    {

        private CollectionInMemDao _dao;
        CollectionService _service;

        [SetUp]
        public void Setup()
        {
            _dao = new CollectionInMemDao();
            _service = new CollectionService(_dao);
        }


        [TestCase("Psychic")]
        [TestCase(null)]
        public void TestGetCollectionByType(string type)
        {
            if (type == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetByType(1, type));
            }
            else
            {
                List<Card> cards = _service.GetByType(1, type);

                Assert.AreEqual(2, cards.Count);
            }
        }

        [TestCase("Pokémon")]
        [TestCase(null)]
        public void TestGetCollectionBySuper(string super)
        {
            if (super == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetBySuper(1, super));
            }
            else
            {
                List<Card> cards = _service.GetBySuper(1, super);

                Assert.AreEqual(3, cards.Count);
            }
        }

        [TestCase("Rare Holo")]
        [TestCase(null)]
        public void TestGetCollectionByRarity(string r)
        {
            if (r == null)
            {
                Assert.Throws<NullArgumentException>(() => _service.GetByRarity(1, r));
            }
            else
            {
                List<Card> cards = _service.GetByRarity(1, r);

                Assert.AreEqual(3, cards.Count);
            }
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void TestGetAllTypes(int id)
        {

            if (id <= 0)
            {
                Assert.Throws<NoUserFoundException>(() => _service.GetAllTypes(id));
            }
            else
            {
                List<string> types = _service.GetAllTypes(id);

                Assert.AreEqual(2, types.Count);
                Assert.AreEqual("Psychic", types[0]);
                Assert.AreEqual("Grass", types[1]);
            }
        }

        [TestCase(1)]
        [TestCase(-1)]
        public void TestGetAllRarities(int id)
        {

            if (id <= 0)
            {
                Assert.Throws<NoUserFoundException>(() => _service.GetAllRarities(id));
            }
            else
            {
                List<string> rarities = _service.GetAllRarities(id);

                Assert.AreEqual(1, rarities.Count);
                Assert.AreEqual("Rare Holo", rarities[0]);

            }
        }

        
    }
}
