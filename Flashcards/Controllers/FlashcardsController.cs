using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Commands.Flashcard;
using Flashcards.Infrastructure.DTO;
using Flashcards.Infrastructure.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FlashcardsController : ApiControllerBase
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
                throw new ArgumentException("Paramerets can not be null.");
            }
            command.FlashcardId = Guid.NewGuid();
            await _flashcardService.CreateAsync(command.Question, command.Answer, command.CategoryId, command.FlashcardId, UserId);

            //location header
            return Created($"/api/flashcard/{command.FlashcardId}", null);
        }

        [HttpGet]
        public async Task <FlashcardQuestionDto> Get()
        {
            return await _flashcardService.GetAsync(UserId);
        }

        [HttpPut]
        public async Task <string> CheckAnswer([FromBody]CheckAnswer command)
        {
            var wynik = await _flashcardService.CheckAnswer(command.FlashcardId, command.Answer);
            if (wynik)
            {
                return "Poprawna odpowiedź.";
            } 
            return "Zła odpowiedź.";
        }
    }
}
