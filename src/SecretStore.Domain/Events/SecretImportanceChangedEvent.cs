using Domain.Common;
using Domain.Entities;

namespace Domain.Events
{
    public class SecretImportanceChangedEvent : BaseDomainEvent
    {
        private readonly Secret _changedImportanceSecret;

        public SecretImportanceChangedEvent(Secret changedImportanceSecret)
        {
            _changedImportanceSecret = changedImportanceSecret;
        }
    }
}