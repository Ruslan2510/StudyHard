using System.Threading;
using System.Threading.Tasks;
using StudyHard.Dto.Auth;

namespace StudyHard.Services.Auth
{
    public interface IAuthService
    {
        public Task RegisterAsync(AuthDto userDto, CancellationToken cancellationToken);
        public Task<TokenDto> LoginAsync(AuthDto userDto, CancellationToken cancellationToken);
    }
}