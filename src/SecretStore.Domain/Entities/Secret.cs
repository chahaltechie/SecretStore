using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;
using Domain.Events;

namespace Domain.Entities
{
    public class Secret : BaseEntity        
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Importance { get; set; }
        public List<SecretItem> Items { get; set; }
        public bool HasImportanceChanged { get; private set; }

        public void ImportanceChanged(Importance newImportance)
        {
            HasImportanceChanged = true;
            this.Importance = newImportance;
            Events.Add(new SecretImportanceChangedEvent(this));
        }
        
    }
}