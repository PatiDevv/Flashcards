using Flashcards.Infrastructure.IRepositories;
using Flashcards.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {


        private readonly IUserService _userService;
        private readonly IFlashcardService _flashcardService;
        private readonly ICategoryService _categoryService;

        public DataInitializer(IUserService userService, IFlashcardService flashcardService, ICategoryService categoryService)
        {
            _userService = userService;
            _flashcardService = flashcardService;
            _categoryService = categoryService;
        }

        public async Task SeedAsync()
        {
            var userId = Guid.NewGuid();
            await _userService.RegisterAsync(userId, "user@email.com", "default user", "secret");
            var tasks = new List<Task>();

            Guid English = await _categoryService.CreateAsync("English", userId);
            Guid Biology = await _categoryService.CreateAsync("Biology", userId);
            Guid Physics = await _categoryService.CreateAsync("Physics", userId);

            tasks.Add(_flashcardService.CreateAsync("pasjonujący", "thrilling", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("świadomy", "aware", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("poprzedzać", "to precede", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("omawiać", "to cover", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("szeroki", "wide", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("wąski", "narrow", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("zarządzać", "to manage", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("dudy", "bagpipes", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("cały i zdrowy", "safe and sound", English, Guid.NewGuid(), userId));
            tasks.Add(_flashcardService.CreateAsync("bardzo szybko, w oka mgnieniu", "in no time (at all)", English, Guid.NewGuid(), userId));

            await Task.WhenAll(tasks);
        }
    }
}
