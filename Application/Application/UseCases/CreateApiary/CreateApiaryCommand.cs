using System.Collections.Generic;
using Ether.Outcomes;
using MediatR;

namespace Hapibee.Backend.Application.Application.UseCases.CreateApiary
{
    public sealed class CreateApiaryCommand : IRequest<IOutcome>
    {
        public CreateApiaryCommand(string apiaryCode, string beekeeperCode, string locationLatitude, string locationLongitude,
            IReadOnlyList<CreateHive> hives)
        {
            ApiaryCode = apiaryCode;
            BeekeeperCode = beekeeperCode;
            LocationLatitude = locationLatitude;
            LocationLongitude = locationLongitude;
            Hives = hives;
        }

        public string ApiaryCode { get; }
        public string BeekeeperCode { get; }
        public string LocationLatitude { get; }
        public string LocationLongitude { get; }
        public IReadOnlyList<CreateHive> Hives { get; }

        public sealed class CreateHive
        {
            public CreateHive(string hiveCode, uint numberOfHandles)
            {
                HiveCode = hiveCode;
                NumberOfHandles = numberOfHandles;
            }

            public string HiveCode { get; }
            public uint NumberOfHandles { get; }
        }
    }
}