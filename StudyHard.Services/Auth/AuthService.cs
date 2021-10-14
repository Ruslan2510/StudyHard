using System;
using System.Threading;
using System.Threading.Tasks;
using StudyHard.Data.Entity;
using StudyHard.Data.Repository;
using StudyHard.Dto.Auth;
using StudyHard.Services.Component.Jwt;
using StudyHard.Services.Helpers;

namespace StudyHard.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly StudyHardRepository _repository;
        public AuthService(StudyHardRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterAsync(AuthDto authDto, CancellationToken cancellationToken)
        {
            var user = await _repository.UsersDataAccess.GetUserByFieldAsync(x => x.Email == authDto.Email, cancellationToken);
            if (user != null)
            {
                throw new Exception("User already exists");
            }
            
            var userEntity = new User
            {
                Email = authDto.Email,
                Password = PasswordHasherHelper.EncodePassword(authDto.Password)
            };

            await _repository.UsersDataAccess.AddAsync(userEntity, cancellationToken);
        }

        public async Task<TokenDto> LoginAsync(AuthDto model, CancellationToken cancellationToken)
        {
            var user = await _repository.UsersDataAccess.GetUserByFieldAsync(x => x.Email == model.Email, cancellationToken);

            if (user == null || user.Password !=  PasswordHasherHelper.EncodePassword(model.Password))
            {
                throw new Exception("Invalid credentials");
            }

            return JwtTokenGenerator.GenerateToken(model.Email);
        }
    }
}