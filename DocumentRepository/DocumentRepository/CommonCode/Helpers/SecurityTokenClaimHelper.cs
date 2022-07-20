using System.Security.Claims;

namespace DocumentRepository.API.CommonCode.Helpers
{
    public static class SecurityTokenClaimHelper
    {
        public static int GetUserIdFromToken(HttpContext context)
        {
            var Identity = context.User.Identity as ClaimsIdentity;
            string userId = Identity.FindFirst("UserId").Value;
            if (!string.IsNullOrEmpty(userId))
            {
                return int.Parse(userId);
            }
            return -1;
        }
    }
}
