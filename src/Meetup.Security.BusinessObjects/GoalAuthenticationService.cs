using AutoMapper;
using Meetup.Security.Entities;
using Meetup.Security.Shared.BusinessObjects;
using Meetup.Security.Shared.Dtos;
using Meetup.Security.Shared.Mappers;
using Meetup.Security.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Security.BusinessObjects
{
    public class GoalAuthenticationService : IGoalAuthenticationService
    {
        public GoalAuthenticationService(IUserRepository userRepository, ITokenRepository tokenRepository, IMapper mapper)
        {
            UserRepository = userRepository;
            TokenRepository = tokenRepository;
            Mapper = mapper;
        }

        private IUserRepository UserRepository { get; set; }

        private IMapper Mapper { get; set; }

        private ITokenRepository TokenRepository { get; set; }

        public UserDto Authenticate(string login, string password)
        {
            var user = UserRepository.List(f => f.Login == login && f.Password == password).FirstOrDefault();
            var dto = Mapper.Map<UserDto>(user);
            return dto;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var list = UserRepository.List();
            var convertedList = Mapper.Map<IEnumerable<UserDto>>(list);
            return convertedList;
        }

        public UserDto GetUser(long id)
        {
            return UserRepository.GetByKey(id).To<UserDto>();
        }

        public IEnumerable<string> GetRolesByUserId(long userId)
        {
            return UserRepository.GetRolesByUserId(userId);
        }

        public void RegisterToken(TokenDto token)
        {
            var entity = Mapper.Map<Token>(token);
            TokenRepository.Add(entity);
        }

        public TokenDto GetToken(Guid jwtId)
        {
            var token = TokenRepository.GetByJwtId(jwtId);
            return Mapper.Map<TokenDto>(token);
        }
    }
}
