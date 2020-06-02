using System;

namespace Flashcards.Infrastructure.Commands.Flashcard
{
    public class CreateFlashcard
    {
        public Guid FlashcardId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid CategoryId { get; set; }
    }
}
