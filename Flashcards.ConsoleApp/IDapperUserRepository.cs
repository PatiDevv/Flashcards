using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;

namespace Flashcards.ConsoleApp
{
    public interface IDapperUserRepository
    {
        int AddUser(string name, string email, string password);
        int DeleteUser(string email);
        int EditUserName(string email);
        User GetUser(string email);
        IEnumerable<User> GetUsers();
        int UpdateUser(Guid id, string name, string email, string password, int points);
        int UpdateUser(User user);
    }
}