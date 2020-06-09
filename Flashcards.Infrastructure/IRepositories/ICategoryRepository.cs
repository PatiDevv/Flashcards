using Flashcards.Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(Guid id);
        Task<Category> GetAsync(string name, Guid userId);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
