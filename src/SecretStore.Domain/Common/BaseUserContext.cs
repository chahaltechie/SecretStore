using System.Runtime.CompilerServices;

namespace Domain.Common
{
    public class BaseUserContext
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }

    public class BaseApplicationContext
    {
        public BaseUserContext UserContext { get; private set; }

        public void SetUserContext(BaseUserContext userContext)
        {
            this.UserContext = userContext;
        }
    }
}