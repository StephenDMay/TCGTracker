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
    public class UserRepoTests
    {

        DbUserRepo _repo;
        ServiceCollection _service = new ServiceCollection();


        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
            var builder = new DbContextOptionsBuilder<CardDbContext>();
            builder.UseSqlServer(config.GetConnectionString("TestDB"));

            CardDbContext conn = new CardDbContext(builder.Options);
            _repo = new DbUserRepo(conn);

            conn.Users.RemoveRange(conn.Users);

            conn.SaveChanges();
        }

        [Test]
        public void TestAddUser()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");

            List<User> all = _repo.GetAll().ToList();

            Assert.AreEqual(1, all.Count);
            Assert.AreEqual("Test", all[0].Username);
            Assert.AreEqual("Test", all[0].FirstName);
            Assert.AreEqual("Test", all[0].LastName);



        }


        [Test]
        public void TestDeleteUser()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");
            


            List<User> all = _repo.GetAll().ToList();
            int id = all[0].Id;
            _repo.Delete(id);

            all = _repo.GetAll().ToList();

            Assert.AreEqual(0, all.Count);


        }

        [Test]
        public void TestGetUserById()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");

            List<User> all = _repo.GetAll().ToList();
            int id = all[0].Id;

            User test = _repo.GetById(id);

            Assert.AreEqual(id, test.Id);
            Assert.AreEqual("Test", test.FirstName);
            Assert.AreEqual("Test", test.LastName);
            Assert.AreEqual("Test", test.Username);

        }

        [Test]
        public void TestAddToCollection()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");
            List<User> all = _repo.GetAll().ToList();
            int id = all[0].Id;


            Card card = new Card
            {
                Id = "base1-75",
                Name = "Lass",
                Type = "",
                SetId = "base1",
                Rarity = "Rare",
                NumberInSet = "75",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/75.png",
                ReleaseYear = 1999,
                supertype = "Trainer",
                hp = 0,
                price = decimal.Parse("0.38")
            };

            _repo.AddToCollection(id, card.Id);

            Assert.AreEqual("base1-75", toAdd.OwnedCards[0].Id);
            Assert.AreEqual("Lass", toAdd.OwnedCards[0].Name);
            Assert.AreEqual("", toAdd.OwnedCards[0].Type);
            Assert.AreEqual("base1", toAdd.OwnedCards[0].SetId);
            Assert.AreEqual("Rare", toAdd.OwnedCards[0].Rarity);
            Assert.AreEqual("75", toAdd.OwnedCards[0].NumberInSet);
            Assert.AreEqual("Ken Sugimori", toAdd.OwnedCards[0].Illustrator);
            Assert.AreEqual("https://images.pokemontcg.io/base1/75.png", toAdd.OwnedCards[0].Image);
            Assert.AreEqual(1999, toAdd.OwnedCards[0].ReleaseYear);
            Assert.AreEqual("Trainer", toAdd.OwnedCards[0].supertype);
            Assert.AreEqual(0, toAdd.OwnedCards[0].hp);
            Assert.AreEqual(decimal.Parse("0.38"), toAdd.OwnedCards[0].price);
        }

        [Test]
        public void TestGetCollection()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");
            List<User> all = _repo.GetAll().ToList();
            int id = all[0].Id;

            Card card = new Card
            {
                Id = "base1-75",
                Name = "Lass",
                Type = "",
                SetId = "base1",
                Rarity = "Rare",
                NumberInSet = "75",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/75.png",
                ReleaseYear = 1999,
                supertype = "Trainer",
                hp = 0,
                price = decimal.Parse("0.38")
            };

            _repo.AddToCollection(id, card.Id);

            List<Card> allCards = _repo.GetUserCollection(id);

            Assert.AreEqual(1, allCards.Count);
        }

        [Test]
        public void TestRemoveFromCollection()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");
            List<User> all = _repo.GetAll().ToList();
            int id = all[0].Id;

            Card card = new Card
            {
                Id = "base1-75",
                Name = "Lass",
                Type = "",
                SetId = "base1",
                Rarity = "Rare",
                NumberInSet = "75",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/75.png",
                ReleaseYear = 1999,
                supertype = "Trainer",
                hp = 0,
                price = decimal.Parse("0.38")
            };

            _repo.AddToCollection(id, card.Id);

            List<Card> allCards = _repo.GetUserCollection(id);

            Assert.AreEqual(1, allCards.Count);

            _repo.RemoveFromCollection(id, card.Id);

            Assert.AreEqual(0, allCards.Count);
        }

        [Test]
        public void TestGetSetCount()
        {
            User toAdd = new User
            {
                FirstName = "Test",
                LastName = "Test",
                Username = "Test",
            };

            _repo.Create(toAdd, "Test");
            List<User> all = _repo.GetAll().ToList();
            int id = all[0].Id;

            Card card = new Card
            {
                Id = "base1-75",
                Name = "Lass",
                Type = "",
                SetId = "base1",
                Rarity = "Rare",
                NumberInSet = "75",
                Illustrator = "Ken Sugimori",
                Image = "https://images.pokemontcg.io/base1/75.png",
                ReleaseYear = 1999,
                supertype = "Trainer",
                hp = 0,
                price = decimal.Parse("0.38")
            };

            _repo.AddToCollection(id, card.Id);

            int count = _repo.GetSetCount(id, card.SetId);

            Assert.AreEqual(1, count);
        }
    }
}
