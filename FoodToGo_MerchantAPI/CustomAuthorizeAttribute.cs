using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FoodToGo_API
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _claimType;
        private readonly string[] _claimValues;

        public CustomAuthorizeAttribute(string claimType, params string[] claimValues)
        {
            _claimType = claimType;
            _claimValues = claimValues;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!user.Claims.Any(c => c.Type == _claimType && _claimValues.Contains(c.Value)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
