using System.Security.Claims;
using Domain.Common;
using Infrastructure.Identity.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SecretStore.API.ActionFilters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _permission;
        private readonly BaseApplicationContext _applicationContext;
        public AuthorizeActionFilter(string permission, BaseApplicationContext applicationContext)
        {
            _permission = permission;
            _applicationContext = applicationContext;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
        
        private bool CheckUserPermission(ClaimsPrincipal user, string permission)
        {
            var userContext = _applicationContext.UserContext;
            // Logic for checking the user permission goes here. 
            
            // Let's assume this user has only read permission.
            return permission == "Read";            
        }
        
    }
    
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string permission)
            : base(typeof(AuthorizeActionFilter))   
        {
            Arguments = new object[] { permission };
        }
    }
}