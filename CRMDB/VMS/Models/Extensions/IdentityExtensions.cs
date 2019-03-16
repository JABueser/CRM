using System.Security.Claims;
using System.Security.Principal;

namespace VMS.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetUserFullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}