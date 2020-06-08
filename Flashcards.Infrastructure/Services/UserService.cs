using Flashcards.Infrastructure.DTO;
using AutoMapper;
using Flashcards.Infrastructure.IRepositories;
using Flashcards.Infrastructure.IServices;
using System;
using System.Threading.Tasks;
using Flashcards.Infrastructure.Extensions;
using NLog;
using Flashcards.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Flashcards.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AccountDto> GetAccountAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            return _mapper.Map<AccountDto>(user);
        }

        public async Task RegisterAsync(Guid userId, string email, string name, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email: {email} already exist. ");
            }
            user = new User(userId, name, email, password);
            await _userRepository.AddAsync(user);
            Logger.Trace($"Zarejestrował sie nowy uzytkownik. Email: {email}, Nazwa: {name}");
        }
        
        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            if (user.Password != password)
            {
                throw new Exception("Invalid credentials.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id);

            Logger.Trace($"Zalogował sie uzytkownik. Email: {email}");
            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
            };
        }

        public async Task<List<PlayerStatisticDto>> GetStatisticsAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(x => new PlayerStatisticDto(x)).ToList();
        }
    }
}
