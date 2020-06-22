using System;

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

        protected Flashcard()
        {

        }

        public Flashcard(string question, string answer, Guid categoryId, Guid flashcardId, Guid userId)
        {
            Id = flashcardId;
            SetQuestion(question);
            SetAnswer(answer);
            CreatedAt = DateTime.UtcNow;
            State = FlashcardState.FirstState;
            NextStateDate = DateTime.UtcNow;
            CategoryId = categoryId;
            UserId = userId;
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
                
                switch (State)
                {
                    case FlashcardState.FirstState:
                        if (FirstStateTimesAnswer == 2)
                        {
                            NextStateDate = DateTime.UtcNow.AddDays(1);
                            points = 1;
                            State = FlashcardState.SecondState;
                        }
                        else
                        {
                            FirstStateTimesAnswer++;
                        }
                        break;
                    case FlashcardState.SecondState:
                        State = FlashcardState.ThirdStage;
                        NextStateDate = DateTime.UtcNow.AddDays(8);
                        points = 2;
                        break;
                    case FlashcardState.ThirdStage:
                        State = FlashcardState.FourthStage;
                        NextStateDate = DateTime.UtcNow.AddDays(8);
                        points = 3;
                        break;
                    case FlashcardState.FourthStage:
                        State = FlashcardState.FifthStage;
                        NextStateDate = DateTime.UtcNow.AddDays(8);
                        points = 4;
                        break;
                    case FlashcardState.FifthStage:
                        State = FlashcardState.Completed;
                        NextStateDate = DateTime.UtcNow.AddDays(8);
                        points = 5;
                        break;
                }
                return points;
            }
            else
            {
                State = FlashcardState.FirstState;
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
            Answer = answer;
        }
    }
}
