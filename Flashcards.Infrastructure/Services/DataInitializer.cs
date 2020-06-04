using Flashcards.Infrastructure.IServices;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;

        public DataInitializer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SeedAsync()
        {
            await _userService.RegisterAsync(Guid.NewGuid(), "user@email.com", "default user", "secret");
        }
    }
}
