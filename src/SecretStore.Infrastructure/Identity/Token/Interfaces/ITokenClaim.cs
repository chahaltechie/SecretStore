using System;
using System.Security.Claims;
using Domain.Common;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity.Token.Interfaces
{
    public interface ITokenClaim<in T> where T : BaseUserContext
    {
        Claim GenerateClaim(T context);
    }
    
    public class ExpiryClaim : ITokenClaim<ApplicationUserContext>
    {
        public Claim GenerateClaim(ApplicationUserContext context)
        {
            var expires = DateTime.Now.AddMinutes(5);
            return new Claim("exp", EpochTime.GetIntDate(expires).ToString(), ClaimValueTypes.Integer64);
        }
    }

    public class NameClaim : ITokenClaim<ApplicationUserContext>
    {
        public Claim GenerateClaim(ApplicationUserContext context)
        {
            return new Claim("UserName", context.Name);
        }
    }

    public class IdentifierCliam : ITokenClaim<ApplicationUserContext>
    {
        public Claim GenerateClaim(ApplicationUserContext context)
        {
            return new Claim("Identifier", context.Id);
        }
    }
    public class IssuerCliam : ITokenClaim<ApplicationUserContext>
    {
        public Claim GenerateClaim(ApplicationUserContext context)
        {
            return new Claim("Issuer", "SecretStoreApp");
        }
    }
    public class RoleCliam : ITokenClaim<ApplicationUserContext>
    {
        public Claim GenerateClaim(ApplicationUserContext context)
        {
            return new Claim("Role", context.Role.Name);
        }
    }
    
}