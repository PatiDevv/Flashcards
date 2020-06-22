using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Prototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static readonly IList<User> _users = new List<User>()
        {
            new User(FlashcardsController.userId, "Arek", "arek@gmail.com", "haslo"),
            new User(new Guid("e4592311-3246-494d-90cd-34856551a42b"), "Patrycja", "patrycja@gmail.com", "haslo"),
        };

  
    }
}
