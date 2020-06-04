using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.Commands.Flashcard
{
    public class CheckAnswer
    {
        public Guid FlashcardId { get; set; }
        public string Answer { get; set; }
    }
}
