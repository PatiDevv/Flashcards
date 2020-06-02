using Flashcards.Core.Domain;
using Flashcards.Infrastructure.IRepositories;
using Flashcards.Infrastructure.IServices;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services
{
    public class FlashcardService : IFlashcardService
    {
        private readonly IFlashcardRepository _flashcardRepository;

        public FlashcardService(IFlashcardRepository flashcardRepository)
        {
            _flashcardRepository = flashcardRepository;
        }

        public async Task CreateAsync(string question, string answer, Guid categoryId, Guid flashcardId)
        {
            var flashcard = new Flashcard(question, answer, categoryId, flashcardId);
            await _flashcardRepository.AddAsync(flashcard);
        }
    }
}
