using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Common.Interfaces;

namespace Infrastructure.Identity.Token
{
    public class UserValidator : IUserValidator<ApplicationUserContext>
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUserContext> ValidateUser(string username, string password)
        {
            var user = await _userRepository.GetUserByNameAsync(username);
            if (user == null)
                return new ApplicationUserContext();

            return new ApplicationUserContext()
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}