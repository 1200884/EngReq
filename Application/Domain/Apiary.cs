using System;
using System.Collections.Generic;
using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    public sealed class Apiary : Aggregate
    {
        private readonly List<Hive> _hives;
        private readonly List<Request> _requests;

        private Apiary()
        {
        }

        public Apiary(string beekeeperCode, string apiaryCode, bool isLocatedInControlledArea, CoordinatePoints location,
            IEnumerable<(string code, uint numberOfHandles)> hives)
        {
            _hives = new List<Hive>();
            _requests = new List<Request>();
            ApiaryCode = apiaryCode;
            BeekeeperCode = beekeeperCode;
            IsLocatedInControlledArea = isLocatedInControlledArea;
            Location = location;
            CreationDate = DateTime.Now;
            CreationStatusType = StatusType.WaitingForApproval;
            CreateHives(hives);

            if (IsLocatedInControlledArea)
            {
                RequestControlledAreaCertification();
            }

            AddDomainEvent(new ApiaryCreatedEvent(BeekeeperCode, ApiaryCode.ToString(), IsLocatedInControlledArea,
                Location.Longitude,
                location.Latitude));
        }

        public string ApiaryCode { get; }
        public string BeekeeperCode { get; }
        public bool IsLocatedInControlledArea { get; }
        public CoordinatePoints Location { get; }
        public DateTime CreationDate { get; }
        public IReadOnlyList<Hive> Hives => _hives;
        public IReadOnlyList<Request> Requests => _requests;
        public StatusType CreationStatusType { get; private set; }

        private void CreateHives(IEnumerable<(string code, uint numberOfHandles)> hives)
        {
            foreach (var (code, numberOfHandles) in hives)
            {
                var hiveEntity = new Hive(code, numberOfHandles);
                AddDomainEvent(new HiveCreatedEvent(BeekeeperCode, hiveEntity.HiveCode, hiveEntity.NumberOfHandles,
                    hiveEntity.NumberOfQueenBees));
                _hives.Add(hiveEntity);
            }
        }

        private void RequestControlledAreaCertification()
        {
            var request = new Request(CreationDate,
                RequestType.ApiaryCreation,
                CertifyingEntityType.ManagementEntityOfControlledAreas);

            _requests.Add(request);

            AddDomainEvent(new RequestControlledAreaCertificationEvent(BeekeeperCode, ApiaryCode.ToString()));
        }
    }
}