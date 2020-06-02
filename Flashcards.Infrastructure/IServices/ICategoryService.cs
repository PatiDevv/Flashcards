using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.IServices
{
    public interface ICategoryService
    {
        Task<Guid> CreateAsync(string name);

    }
}
