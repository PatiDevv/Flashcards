using Flashcards.Core.Domain;
using Flashcards.Infrastructure.Initializer;
using Flashcards.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Repositories
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private static readonly ISet<Flashcard> _flashcards = new HashSet<Flashcard>()
        { 
            new Flashcard("pasjonujący", "thrilling", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("poprzedzać", "to precede", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("świadomy", "aware", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("omawiać", "to cover", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("szeroki", "wide", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("wąski", "narrow", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("zarządzać", "to manage", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("dudy", "bagpipes", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("cały i zdrowy", "safe and sound", CategoryIds.English, Guid.NewGuid()),
            new Flashcard("bardzo szybko, w oka mgnieniu", "in no time (at all)", CategoryIds.English, Guid.NewGuid())
        };

        public async Task<Flashcard> GetAsync(Guid id)
        => await Task.FromResult(_flashcards.SingleOrDefault(x => x.Id == id));
        
        public async Task<IEnumerable<Flashcard>> BrowseAsync()
        => await Task.FromResult(_flashcards.AsEnumerable());
        
        public async Task AddAsync(Flashcard flashcard)
        {
            _flashcards.Add(flashcard);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Flashcard flashcard)
        {
            await Task.CompletedTask;
        }  

        public async Task DeleteAsync(Flashcard flashcard)
        {
            _flashcards.Remove(flashcard);
            await Task.CompletedTask;
        }
    }
}
