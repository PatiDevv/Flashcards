using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.DTO
{
    public class FlashcardQuestionDto
    {
        public FlashcardQuestionDto()
        {
        }

        public FlashcardQuestionDto(Guid flashcardId, string question, IList<string> answer)
        {
            FlashcardId = flashcardId;
            Question = question;
            Answer = answer;
        }

        public Guid FlashcardId { get; set; }
        public string Question { get; set; }
       
        public IList<string> Answer { get; set; } 
    }
}
