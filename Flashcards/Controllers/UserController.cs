using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Infrastructure.DTO;
using Flashcards.Infrastructure.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServce;

        public UserController(IUserService userServce)
        {
            _userServce = userServce;
        }

        [HttpGet]
        public async Task<List<PlayerStatisticDto>> BrowseStatistic()
        {
            return await _userServce.GetStatisticsAsync();
        }
    }
}