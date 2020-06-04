using System.Threading.Tasks;
using Flashcards.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // POST: api/Category
        [HttpPost("{name}")]
        public async Task<IActionResult> Post(string name)
        {
            var id = await _categoryService.CreateAsync(name);
            
            return Created($"/api/Category/{id}", null);
        }
    }
}
