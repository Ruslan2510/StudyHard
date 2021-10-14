using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using StudyHard.Dto.Configurations;
using System;

namespace StudyHard.Web.Filters
{
    public class ItlegAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var analyticsConfig = (IOptions<AnalyticsConfiguration>)context.HttpContext.RequestServices.GetService(typeof(IOptions<AnalyticsConfiguration>));

                var apiKey = context.HttpContext.Request.Headers["Api-Key"];
                if (string.IsNullOrEmpty(analyticsConfig?.Value?.AppKey) || apiKey != analyticsConfig.Value.AppKey)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
