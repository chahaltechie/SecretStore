using Application.Authorization.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class UserContext : IUserContext
    {
        public string UserName { get; }
        public string UserRole { get; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetUserContext();
        }

        private void SetUserContext()
        {
            
        }
    }
}