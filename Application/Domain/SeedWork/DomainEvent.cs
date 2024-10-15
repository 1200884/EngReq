using System;

namespace Hapibee.Backend.Application.Domain.SeedWork
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent(string beekeeperCode)
        {
            BeekeeperCode = beekeeperCode;
            EventDate = DateTime.Now;
        }

        public string BeekeeperCode { get; }
        public DateTime EventDate { get; }
    }
}