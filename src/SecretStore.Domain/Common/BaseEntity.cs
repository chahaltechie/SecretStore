using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "pk")] public string PartitionKey { get; set; }
        [JsonProperty(PropertyName = "un")] public string UniqueKey { get; set; }
        public string Type { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        protected List<BaseDomainEvent> Events { get; set; }
    }
}