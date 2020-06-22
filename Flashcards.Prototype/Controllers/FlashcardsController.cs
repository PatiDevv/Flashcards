using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Prototype.Controllers
{
    [Route("flashcard")]
    public class FlashcardsController : Controller
    {
        public static readonly Guid English = new Guid("80c76be5-646e-49b2-a1df-71336b0d74f4");
        public static readonly Guid userId = new Guid("8a5395fd-96f1-40ed-9e43-033f05e9929d");

        private static readonly IList<Flashcard> _fiszki = new List<Flashcard>()
        {
             new Flashcard("pasjonujący", "thrilling", English, Guid.NewGuid(), userId),
             new Flashcard("świadomy", "aware", English, Guid.NewGuid(), userId),
             new Flashcard("poprzedzać", "to precede", English, Guid.NewGuid(), userId),
             new Flashcard("omawiać", "to cover", English, Guid.NewGuid(), userId),
             new Flashcard("szeroki", "wide", English, Guid.NewGuid(), userId),
             new Flashcard("wąski", "narrow", English, Guid.NewGuid(), userId),
             new Flashcard("zarządzać", "to manage", English, Guid.NewGuid(), userId),
             new Flashcard("dudy", "bagpipes", English, Guid.NewGuid(), userId),
             new Flashcard("cały i zdrowy", "safe and sound", English, Guid.NewGuid(), userId),
             new Flashcard("bardzo szybko, w oka mgnieniu", "in no time (at all)", English, Guid.NewGuid(), userId),
        };

        [HttpGet]
        [Route("browse")]
        public IEnumerable<User> GetEverything()
        {
            return UserController._users.Select(x => {
                x.Flashcards = _fiszki.Where(f => f.UserId == x.Id).ToList();
                return x;
            });
        }

        // GET: Flashcards/userid
        [HttpGet]
        public IEnumerable<Flashcard> Details(Guid userId)
        {
            return _fiszki.Where(x => x.UserId == userId);
        }

        [HttpPost]
        public void Create(string Question, string Answer, Guid CategoryId, Guid FlashcardId, Guid UserId)
        {
            var user = UserController._users.First(x => x.Id == UserId);
            if(user == null)
            {
                throw new Exception("User does not exists");
            }

            var category = CategoryController._category.First(x => x.Id == CategoryId);
            if (category == null)
            {
                throw new Exception("category does not exists");
            }

            var fiszka = new Flashcard(Question, Answer, CategoryId, FlashcardId, UserId);
            _fiszki.Add(fiszka);
        }

        [HttpPut]
        public void CopyFlashcards(Guid fromUserId, Guid toUserId, Guid categoryId)
        {
            var user = UserController._users.First(x => x.Id == toUserId);
            if (user == null)
            {
                throw new Exception("User does not exists");
            }

            var fiszki = _fiszki.Where(x => x.UserId == fromUserId && x.CategoryId == categoryId).ToList();

            var kategoria = CategoryController._category.First(x => x.Id == categoryId);

            if(kategoria == null)
            {
                throw new Exception("category does not exists");
            }

            var nowaKategoria = new Category(kategoria.Name, toUserId);
            CategoryController._category.Add(nowaKategoria);

            foreach(var fiszka in fiszki)
            {
                var skopiowanaFiszka = new Flashcard(fiszka.Question, fiszka.Answer, nowaKategoria.Id, Guid.NewGuid(), toUserId);

                _fiszki.Add(skopiowanaFiszka);
            }
        }
    }
}