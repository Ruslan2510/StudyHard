using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using StudyHard.Data.Repository;

namespace StudyHard.Web.Validators
{
    public class UserJwtValidator: JwtBearerEvents
    {
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            try
            {
                var repository = context.HttpContext.RequestServices.GetRequiredService<StudyHardRepository>();
                var email = context.Principal?.Claims.First(c => c.Type == ClaimTypes.Email)?.Value;
                var checkUser =
                    await repository.UsersDataAccess.GetUserByFieldAsync(x => x.Email == email, new CancellationToken());

                if (checkUser == null)
                {
                    context.Fail("invalid_token");
                }
                else
                {
                    context.Success();
                }
            }
            catch (Exception e)
            {
                context.Fail(e.Message);
            }
        }
    }
}