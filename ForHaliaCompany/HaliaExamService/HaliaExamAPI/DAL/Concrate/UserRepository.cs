using HaliaExamAPI.DAL.Abstract;
using HaliaExamAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace HaliaExamAPI.DAL.Concrate
{
    public class UserRepository : IUserService
    {
        public readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public User Insert(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public string CheckEmail(string email)
        {
            if (_context.users.Where(u => u.email == email).FirstOrDefault() != null)
            {
                return "Email is already exist.";
            }
            else
            {
                return null;
            }
        }

        public string CheckPhone(string phone)
        {
            if (_context.users.Where(u => u.phone == phone).FirstOrDefault() != null)
            {
                return "Phone is already exist.";
            }
            else
            {
                return null;
            }
        }

        public bool IsLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        public bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public bool IsValidPassword(string password)
        {
            return
               password.Any(c => IsLetter(c)) &&
               password.Any(c => IsDigit(c));
        }

        public User LoginControl(Login user)
        {
            return _context.users.Where(u=> u.email == user.Email && u.password == user.Password).FirstOrDefault();
        }

        public List<User> GetUsersInfo()
        {
            var users = _context.users.OrderByDescending(u=>u.id).ToList();
            return users;
        }

        public User GetSessionInfo(string email, string password)
        {
            var user = _context.users.Where(u => u.email == email && u.password == password).FirstOrDefault();
            return user;
        }
    }
}