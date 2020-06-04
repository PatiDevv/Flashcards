using Flashcards.Core.Domain;
using Flashcards.Infrastructure.Initializer;
using Flashcards.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly ISet<Category> _category = new HashSet<Category>()
        {
            new Category("English", CategoryIds.English), new Category("Biology", CategoryIds.Biology), new Category("Physics", CategoryIds.Physics)
        };

        public async Task<Category> GetAsync(Guid id)
        => await Task.FromResult(_category.SingleOrDefault(x => x.Id == id));

        public async Task<Category> GetAsync(string name)
        => await Task.FromResult(_category.SingleOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant()));
    
        public async Task<IEnumerable<Category>> GetAllAsync()
        => await Task.FromResult(_category.AsEnumerable());

        public async Task AddAsync(Category category)
        {
            _category.Add(category);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Category category)
        {
            await Task.CompletedTask;
        }
        
        public async  Task DeleteAsync(Category category)
        {
            _category.Remove(category);
            await Task.CompletedTask;
        }

    }
}
