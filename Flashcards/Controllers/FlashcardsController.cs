using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Flashcard;
using Flashcards.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly IFlashcardService _flashcardService;

        public FlashcardsController(IFlashcardService flashcardService)
        {
            _flashcardService = flashcardService;
        }

        // POST: api/Flashcards
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateFlashcard command)
        {
            if (command == null)
            {
                throw new ArgumentException("Paramerets can not be null");
            }
            command.FlashcardId = Guid.NewGuid();
            await _flashcardService.CreateAsync(command.Question, command.Answer, command.CategoryId, command.FlashcardId);

            //location header
            return Created($"/api/flashcard/{command.FlashcardId}", null);
        }
    }
}
