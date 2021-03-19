namespace Domain.Common
{
    public class BaseUserContext
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}