namespace SecretStore.API.Models.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}