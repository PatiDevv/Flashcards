using Flashcards.Core.Domain;
using Flashcards.Infrastructure.IRepositories;
using Flashcards.Infrastructure.IServices;
using System;
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

        public async Task<Guid> CreateAsync(string name, Guid userId)
        {
            var category = await _categoryRepository.GetAsync(name, userId);
            if(category != null)
            {
                throw new Exception($"Category with name: {name} already exist. ");
            }
            category = new Category(name, userId);
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }

        //metoda
        // moze byc z modyfikatorem dostepu (public private protected)
        // public ...
        // moze byc asynchroniczna
        // public async
        // ale nie musi byc
        // ma typ zwracany jakis jakikolwiek bool int Task Task<bool> Task<IEnumerable<User>> void - Task - nie zwraca wartosci
        // nazwa GetAsync
        // parametry z określonymi TYPAMI string name, Task, IEnumerable nazwaZmiennej
        // Guid userId
        // cialo w klamrach

        //wywołanie metody
        // nazwa metody i nawiasy ktore oznaczaja wykonanie metody () i parametry jesli jakies sa (name) SetName(name) 
        // <- tutaj nie okreslamy typow parametrow bo juz sa zadeklarowane
    }
}
