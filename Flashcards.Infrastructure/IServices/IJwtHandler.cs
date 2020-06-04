using Flashcards.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.IServices
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId);
    }
}
