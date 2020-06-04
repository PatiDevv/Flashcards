using Flashcards.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.IServices
{
    public interface IFlashcardService
    {
        Task CreateAsync(string question, string answer, Guid categoryId, Guid flashcardId);
        Task<FlashcardQuestionDto> GetAsync();
        Task<bool> CheckAnswer(Guid flashcardIds, string answer);
    }
}
