using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    internal sealed class HiveCreatedEvent : DomainEvent
    {
        public HiveCreatedEvent(string beekeeperCode, string hiveCode, uint numberOfHandles, uint numberOfQueenBees) :
            base(beekeeperCode)
        {
            HiveCode = hiveCode;
            NumberOfHandles = numberOfHandles;
            NumberOfQueenBees = numberOfQueenBees;
        }

        public string HiveCode { get; }

        public uint NumberOfHandles { get; }

        public uint NumberOfQueenBees { get; }
    }
}