using Flashcards.Core.Domain;
using Flashcards.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _user = new HashSet<User>();

        public async Task<User> GetAsync(Guid id)
        => await Task.FromResult(_user.SingleOrDefault(x => x.Id == id));

        public async Task AddAsync(User user)
        {
            _user.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(User user)
        {
            _user.Remove(user);
            await Task.CompletedTask;
        }
}   }
