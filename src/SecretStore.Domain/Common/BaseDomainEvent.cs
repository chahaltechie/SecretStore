using System;

namespace Domain.Common
{
    public class BaseDomainEvent
    {
        public DateTime DateOccurTime { get; init; } = DateTime.UtcNow;
    }
}