using System;
using System.Collections.Generic;

namespace Flashcards.Core.Domain
{
    public class User : Entity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime CreateAt { get; protected set; }
        public ICollection<Flashcard> Flashcards { get; set; }
        public int Points { get; protected set; }

        protected User()
        {
        }

        public User(Guid id, string name, string email, string password)
        {
            Id = id;
            SetName(name);
            SetEmail(email);
            SetPassword(password);
            CreateAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"User can not have an empty name.");
            }
            Name = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception($"User can not have empty email. ");
            }
            Email = email;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception($"User can not have an empty password.");
            }
            Password = password;
        }

        public void CheckAndProcessAnswer(Flashcard flashcard, string answer)
        {
            int points = flashcard.CheckAndProcessAnswer(answer);
            Points += points;
        }
    }
}
