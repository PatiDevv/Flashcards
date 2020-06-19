using Flashcards.Core.Domain;
using Flashcards.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private static readonly ISet<Flashcard> _flashcards = new HashSet<Flashcard>();

        public async Task<Flashcard> GetAsync(Guid id)
            => await Task.FromResult(_flashcards.SingleOrDefault(x => x.Id == id));
        
        public async Task<IEnumerable<Flashcard>> BrowseAsync(Guid userId)
            => await Task.FromResult(_flashcards.Where(x => x.UserId == userId).AsEnumerable());
        
        public async Task AddAsync(Flashcard flashcard)
        {
            _flashcards.Add(flashcard);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Flashcard flashcard)
        {
            await Task.CompletedTask;
        }  

        public async Task DeleteAsync(Flashcard flashcard)
        {
            _flashcards.Remove(flashcard);
            await Task.CompletedTask;
        }

        public async  Task<IEnumerable<Flashcard>> BrowseAsync(Guid userId, Guid categoryId)
            => await Task.FromResult(_flashcards.Where(x => x.UserId == userId && x.CategoryId == categoryId).AsEnumerable());

        public async Task AddRangeAsync(IEnumerable<Flashcard> flashcards)
        {
            flashcards.ToList().ForEach(x => _flashcards.Add(x));
            await Task.CompletedTask;
        }
    }
}
