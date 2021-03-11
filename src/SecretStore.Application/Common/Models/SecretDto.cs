using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Models
{
    public class SecretDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Importance { get; set; }
        public List<SecretItem> Items { get; set; }
    }
}