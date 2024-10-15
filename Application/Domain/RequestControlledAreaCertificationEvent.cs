using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    internal class RequestControlledAreaCertificationEvent : DomainEvent
    {
        public RequestControlledAreaCertificationEvent(string beekeeperCode, string apiaryCode) : base(beekeeperCode)
        {
            ApiaryCode = apiaryCode;
        }

        public string ApiaryCode { get; }
    }
}