using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
