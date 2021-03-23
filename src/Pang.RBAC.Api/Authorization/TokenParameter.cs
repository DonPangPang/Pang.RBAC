using Microsoft.AspNetCore.Authorization;

namespace Pang.RBAC.Api.Authorization
{
    public class TokenParameter : IAuthorizationRequirement
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessExpiration { get; set; }
        public int RefreshExpiration { get; set; }
    }
}