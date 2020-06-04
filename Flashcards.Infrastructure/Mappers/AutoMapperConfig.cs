using AutoMapper;
using Flashcards.Core.Domain;
using Flashcards.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    { 
    public static IMapper Initialize()
    => new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<User, AccountDto>();
    })
        .CreateMapper();
    }
}
