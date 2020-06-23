using System;

namespace Flashcards.Core.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public Category(string name, Guid userId)
        {
            SetName(name);
            UserId = userId;
        }

        public Category(string name, Guid categoryId, Guid userId)
        {
            SetName(name);
            Id = categoryId;
            UserId = userId;
        }
        public Category()
        {
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Category can not have an empty name.");
            }
            Name = name;
        }
    }
}
