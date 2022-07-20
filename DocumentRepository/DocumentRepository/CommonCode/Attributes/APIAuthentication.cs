using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace DocumentRepository.API.CommonCode.Attributes
{
    public class APIAuthentication : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext authorizeFilterContext)
        {
            AuthenticationHeaderValue.TryParse(authorizeFilterContext.HttpContext.Request.Headers["Authorization"], out AuthenticationHeaderValue token);
            if (token == null || (token!=null && String.IsNullOrEmpty(token.ToString())))
            {
                authorizeFilterContext.Result = new UnauthorizedResult();
                return;
            }
            var Identity = authorizeFilterContext.HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claim = Identity.Claims;
            var ClaimUserId = Identity.FindFirst("UserId").Value;
            if (string.IsNullOrEmpty(ClaimUserId))
            {
                authorizeFilterContext.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
