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
using CardCollection.Services;
using CardCollection.Repos.InMemDao;
using CardCollection.Exceptions;

namespace CardCollectionTests.ServiceTests
{
    class UserServiceTests
    {
        private UserInMemDao _dao;
        UserService _service;

        [SetUp]
        public void Setup()
        {
            _dao = new UserInMemDao();
            _service = new UserService(_dao);
        }

        [Test]
        public void TestCreateUser()
        {
            User toCreate = new User
            {
                Id = 2,
                Username = "Test",
                FirstName = "Test F",
                LastName = "Test L"
            };
            string pwd = "password";

            User toTest = _service.Create(toCreate, pwd);

            Assert.AreEqual(toCreate.FirstName, toTest.FirstName);
            Assert.AreEqual(toCreate.LastName, toTest.LastName);
            Assert.AreEqual(toCreate.Username, toTest.Username);

        }

        [Test]
        public void TestDeleteUser()
        {
            _service.Delete(1);
        }

        [Test]
        public void TestGetUserCollection()
        {
            List<Card> collection = _service.GetUserCollection(1);

            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual("Nidoking", collection[0].Name);
            Assert.AreEqual("base1-11", collection[0].Id);
            Assert.AreEqual("Grass", collection[0].Type);
            Assert.AreEqual("base1", collection[0].SetId);
            Assert.AreEqual("Rare Holo", collection[0].Rarity);
            Assert.AreEqual("11", collection[0].NumberInSet);
            Assert.AreEqual("Ken Sugimori", collection[0].Illustrator);
            Assert.AreEqual("https://images.pokemontcg.io/base1/11.png", collection[0].Image);
            Assert.AreEqual(1999, collection[0].ReleaseYear);
            Assert.AreEqual("Pokémon", collection[0].supertype);
            Assert.AreEqual(90, collection[0].hp);
            Assert.AreEqual(decimal.Parse("0.38"), collection[0].price);

        }


        [TestCase(null, "Nidoking", "Grass", "base1", "Rare Holo", "11", "Ken Sugimori",
            "https://images.pokemontcg.io/base1/11.png", 1999, "Pokémon", 90, "0.38")]
        public void TestAddNullCardIdToCollection(string id, string name, string type,
            string set, string rarity, string num, string illustrator, string img, int year, string super, int hp, string price)
        {
            Card toAdd = new Card
            {
                Id = id,
                Name = name,
                Type = type,
                SetId = set,
                Rarity = rarity,
                NumberInSet = num,
                Illustrator = illustrator,
                Image = img,
                ReleaseYear = year,
                supertype = super,
                hp = hp,
                price = decimal.Parse(price)
            };

            Assert.Throws<NullArgumentException>(() => _service.AddToCollection(1, toAdd.Id));
        }



        [TestCase(null, "Nidoking", "Grass", "base1", "Rare Holo", "11", "Ken Sugimori",
            "https://images.pokemontcg.io/base1/11.png", 1999, "Pokémon", 90, "0.38")]
        public void TestRemoveNullCardValueFromCollection(string id, string name, string type,
            string set, string rarity, string num, string illustrator, string img, int year, string super, int hp, string price)
        {
            Card toRemove = new Card
            {
                Id = id,
                Name = name,
                Type = type,
                SetId = set,
                Rarity = rarity,
                NumberInSet = num,
                Illustrator = illustrator,
                Image = img,
                ReleaseYear = year,
                supertype = super,
                hp = hp,
                price = decimal.Parse(price)
            };

            Assert.Throws<NullArgumentException>(() => _service.RemoveFromCollection(1, toRemove.Id));
        }

    }
}
