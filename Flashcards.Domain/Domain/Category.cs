using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Core.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name)
        {
            SetName(name);
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
