using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.IRepositories
{
    public interface IFlashcardRepository
    {
        Task<Flashcard> GetAsync(Guid id);
        Task<IEnumerable<Flashcard>> BrowseAsync(Guid userId);
        Task<IEnumerable<Flashcard>> BrowseAsync(Guid userId, Guid categoryId);
        Task AddAsync(Flashcard flashcard);

        Task AddRangeAsync(IEnumerable<Flashcard> flashcards);
        Task UpdateAsync(Flashcard flashcard);
        Task DeleteAsync(Flashcard flashcard);
    }
}
