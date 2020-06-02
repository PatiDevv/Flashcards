using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Core.Domain
{
    public class Flashcard : Entity
    {
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public FlashcardState State { get; protected set; }
        public DateTime NextStateDate { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public Guid UserId { get; protected set; }
        public int FirstStateTimesAnswer { get; protected set; }

        public Flashcard(string question, string answer)
        {
            SetQuestion(question);
            SetAnswer(answer);
            CreatedAt = DateTime.UtcNow;
            State = FlashcardState.FirstState;
            NextStateDate = DateTime.UtcNow;
        }

        public int CheckAndProcessAnswer(string answer)
        {
            if(NextStateDate > DateTime.UtcNow)
            {
                throw new Exception($"You can't answer to flashcard before: {NextStateDate}");
            }
            if(answer == Answer)
            {
                int points = 0;
                NextStateDate = DateTime.UtcNow.AddDays(8);
                switch (State)
                {
                    case FlashcardState.FirstState:
                        if (FirstStateTimesAnswer == 2)
                        {
                            points = 1;
                            State = FlashcardState.SecondState;
                        }
                        else
                            FirstStateTimesAnswer++;
                        break;
                    case FlashcardState.SecondState:
                        State = FlashcardState.ThirdStage;
                        points = 2;
                        break;
                    case FlashcardState.ThirdStage:
                        State = FlashcardState.FourthStage;
                        points = 3;
                        break;
                    case FlashcardState.FourthStage:
                        State = FlashcardState.FifthStage;
                        points = 4;
                        break;
                    case FlashcardState.FifthStage:
                        State = FlashcardState.Completed;
                        points = 5;
                        break;
                }
                return points;
            }
            else
            {
                State = FlashcardState.FirstState;
                NextStateDate = DateTime.UtcNow.AddDays(1);
                return -1;
            }
        }

        private void SetQuestion(string question)
        {
            if(string.IsNullOrWhiteSpace(question))
            {
                throw new Exception($"Question can not be empty.");
            }
            Question = question;
        }

        private void SetAnswer(string answer)
        {
            if(string.IsNullOrWhiteSpace(answer))
            {
                throw new Exception($"Answer can not be empty.");
            }
        }
    }
}
