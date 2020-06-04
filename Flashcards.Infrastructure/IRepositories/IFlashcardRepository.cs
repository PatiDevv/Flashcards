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
        Task<IEnumerable<Flashcard>> BrowseAsync();
        Task AddAsync(Flashcard flashcard);
        Task UpdateAsync(Flashcard flashcard);
        Task DeleteAsync(Flashcard flashcard);
    }
}
