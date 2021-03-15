namespace Application.Authorization.Interfaces
{
    public interface IUserContext
    {
        public string UserName { get; }
        public string UserRole { get; }
    }
}