using ProjectArcher_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArcher_Backend.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly postgresContext _context;
        public IdentityService(postgresContext context)
        {
            _context = context;
        }

        public (string, string) ComputeHash(string plainText)
        {
            byte[] saltBytes;

            int minSaltSize = 4;
            int maxSaltSize = 8;
            Random random = new Random();

            int saltSize = random.Next(minSaltSize, maxSaltSize);
            saltBytes = new byte[saltSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltBytes);


            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
            for (int i = 0; i < plainTextBytes.Length; i++) plainTextWithSaltBytes[i] = plainTextBytes[i];
            for (int i = 0; i < saltBytes.Length; i++) plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];


            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];
            for (int i = 0; i < hashBytes.Length; i++) hashWithSaltBytes[i] = hashBytes[i];
            for (int i = 0; i < saltBytes.Length; i++) hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return (hashValue, salt);
        }

        public bool Login(string username, string password)
        {
            var hash = ComputeHash(password);
            return _context.User.First(user => user.Username == username).Password == hash.Item1;
        }

        public bool Register(string username, string password)
        {
            var hash = ComputeHash(password);
            _context.User.Add(new User()
            {
                Username = username,
                Password = hash.Item1,
                Salt = hash.Item2
            });
            _context.SaveChanges();
            return _context.User.Any(user => user.Username == username);
        }
    }
}
