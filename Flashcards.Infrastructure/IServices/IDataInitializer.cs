using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.IServices
{
    public interface IDataInitializer
    {
        Task SeedAsync();
    }
}
