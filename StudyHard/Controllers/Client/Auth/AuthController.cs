using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyHard.Dto.Auth;
using StudyHard.Services.Auth;


namespace StudyHard.Web.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task RegisterAsync(AuthDto userDto, CancellationToken cancellationToken)
        {
            await _authService.RegisterAsync(userDto, cancellationToken);
        }
        
        [HttpPost("login")]
        public async Task<TokenDto> LoginAsync (AuthDto userDto, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(userDto, cancellationToken);
        }
    }
}