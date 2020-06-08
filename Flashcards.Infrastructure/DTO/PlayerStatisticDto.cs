using Flashcards.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.DTO
{
    public class PlayerStatisticDto
    {
        public PlayerStatisticDto(User user)
        {
            Name = user.Name;
            Points = user.Points;
        }

        public string Name { get; set; }
        public int Points { get; set; }
    }
}
