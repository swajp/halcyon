using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Halcyon.src
{
    public class User
    {
        public int Id { get; }
        public string Username { get; }
        public int Role { get; set; }
        public byte[] PasswordHash { get; internal set; }
        public byte[] PasswordSalt { get; internal set; }

        public User(int id,string username, string password, int role)
        {
            Id = id;
            Username = username;
            Role = role;
            SqlRepository.CreateUser(username,password);
        }

        public User(int id,string username, byte[] passwordHash, byte[] passwordSalt, int role)
        {
            Id = id;
            Username = username;
            Role = role;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public bool VerifyPassword(string password)
        {
            byte[] hash;
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return hash.SequenceEqual(PasswordHash);
        }
    }
}
