using System.Runtime.CompilerServices;

namespace Domain.Common
{
    public class BaseUserContext
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        
        public string Permission { get; set; }
    }
}