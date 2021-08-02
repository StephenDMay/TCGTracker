using CardCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CardCollection.Entities;
using CardCollection.Helpers;

namespace CardCollection.Repos
{
    public class DbUserRepo : IUserRepo
    {


        CardDbContext _context;

        public DbUserRepo(CardDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            User user = _context.Users.SingleOrDefault(x => x.Username == username);
            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Update(User userParam, string password)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }



        public int AddToCollection(int id, string cardId)
        {
            User user = _context.Users.Find(id);
            Card card = _context.Cards.Find(cardId);

            user.OwnedCards.Add(card);
            card.Owners.Add(user);

            _context.SaveChanges();
            return user.Id;
        }

        public List<Card> GetUserCollection(int id)
        {
            User user = _context.Users.Find(id);
            user.OwnedCards = _context.Cards.Where(c => c.Owners.Contains(user)).ToList();
            return user.OwnedCards;
        }

        public string RemoveFromCollection(int id, string cardId)
        {
            Card toRemove = _context.Cards.Find(cardId);
            User user = _context.Users.Include(user => user.OwnedCards).SingleOrDefault(u => u.Id == id);


            user.OwnedCards.Remove(user.OwnedCards.Single(c => c.Id == cardId));
            _context.SaveChanges();


            return $"Card {cardId} removed.";
        }

        public int GetSetCount(int id, string setId)
        {
            Sets set = _context.Sets.Find(setId);
            User user = _context.Users.Find(id);
            List<Card> card = _context.Cards.Where(c => c.Owners.Contains(user) && c.SetId == setId).ToList();
            int num = card.Count;
            return card.Count;
        }

        public int GetSetTotal(int id, string setId)
        {
            Sets set = _context.Sets.Find(setId);
            List<Card> cards = _context.Cards.Where(c => c.SetId == set.Id).ToList();
            return cards.Count;
        }
    }
}
