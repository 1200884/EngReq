using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    internal class ApiaryCreatedEvent : DomainEvent
    {
        public ApiaryCreatedEvent(string beekeeperCode, string apiaryCode, bool isLocatedInControlledArea,
            double locationLongitude, double locationLatitude) : base(beekeeperCode)
        {
            ApiaryCode = apiaryCode;
            IsLocatedInControlledArea = isLocatedInControlledArea;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
        }

        public bool IsLocatedInControlledArea { get; }
        public double LocationLongitude { get; }
        public double LocationLatitude { get; }
        public string ApiaryCode { get; }
    }
}