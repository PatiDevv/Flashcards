using Flashcards.Infrastructure.DTO;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.IServices
{
    public interface IUserService
    {
        Task<AccountDto> GetAccountAsync(Guid userId);
        Task RegisterAsync(Guid userId, string email, string name, string password);
        Task<TokenDto> LoginAsync(string email, string password);
    }
}
