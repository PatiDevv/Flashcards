using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.DTO
{
    public class TokenDto
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
