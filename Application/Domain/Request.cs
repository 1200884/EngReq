using System;
using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    public sealed class Request : Entity
    {
        public Request(DateTime startDate, RequestType typeOfRequest, CertifyingEntityType certifyingEntityType)
        {
            StartDate = startDate;
            RequestStatusType = StatusType.WaitingForApproval;
            TypeOfRequest = typeOfRequest;
            CertifyingEntityType = certifyingEntityType;
        }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StatusType RequestStatusType { get; set; }
        public RequestType TypeOfRequest { get; set; }
        public CertifyingEntityType CertifyingEntityType { get; set; }
        public Apiary Apiary { get; }
    }
}