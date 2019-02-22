using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Socialnetwork.Webclient.Helpers
{
    public static class ControllerHelper
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    return userIdValue;
                }
            }
            return null;
        }
    }
}
