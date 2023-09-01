using HaliaExamAPI.Models;
using System.Collections.Generic;

namespace HaliaExamAPI.DAL.Abstract
{
    public interface IUserService
    {
        User Insert(User user);

        string CheckEmail(string email);

        string CheckPhone(string phone);

        bool IsLetter(char c);

        bool IsDigit(char c);

        bool IsValidPassword(string password);

        User LoginControl(Login user);

        List<User> GetUsersInfo();

        User GetSessionInfo(string email,string password);
    }
}