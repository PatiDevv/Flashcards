using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;

namespace Flashcards.ConsoleApp
{
    public interface IDapperCategoryRepository
    {
        int DeleteCategory(string name, Guid userId);
        IEnumerable<Category> GetCategories(Guid userId);
        Category GetCategory(string name, Guid userId);
    }
}