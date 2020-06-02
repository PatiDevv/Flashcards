using Flashcards.Core.Domain;
using Flashcards.Infrastructure.IRepositories;
using Flashcards.Infrastructure.IServices;
using Flashcards.Infrastructure.Repositories;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task <Guid>CreateAsync(string name)
        {
            var category = await _categoryRepository.GetAsync(name);
            if(category != null)
            {
                throw new Exception($"Category with name: {name} already exist. ");
            }
            category = new Category(name);
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}
