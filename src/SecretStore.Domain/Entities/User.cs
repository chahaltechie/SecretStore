using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        
        public string Permission { get; set; }
    }
}