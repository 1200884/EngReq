using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ether.Outcomes;
using Hapibee.Backend.Application.Domain;
using Hapibee.Backend.Application.Domain.SeedWork;
using MediatR;

namespace Hapibee.Backend.Application.Application.UseCases.CreateInspection
{
    internal sealed class CreateApiaryCommandHandler : IRequestHandler<CreateInspectionCommand, IOutcome>
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly IManagementEntityOfControlledAreasGateway _managementEntityOfControlledAreasGateway;
        private readonly IUnitOfWork _unitOfWork;

        public CreateApiaryCommandHandler(
            IManagementEntityOfControlledAreasGateway managementEntityOfControlledAreasGateway,
            IDomainEventDispatcher dispatcher, IInspectionRepository inspectionRepository, IUnitOfWork unitOfWork)
        {
            _managementEntityOfControlledAreasGateway = managementEntityOfControlledAreasGateway;
            _dispatcher = dispatcher;
            _inspectionRepository = inspectionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IOutcome> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
        {
            

            var inspectionLookup = await _inspectionRepository.Find(request.InspectionCode);
            if (inspectionLookup.Success)
            {
                return Outcomes.Failure().WithMessage($"Inspection with InspectionCode: {request.InspectionCode} already exists");
            }

            
            
            var inspection = new Inspection(request.InspectionCode , request.BeekeeperCode,
                 request.HiveCode ,request.HasPolen ,request.Hashoney,
            request.HasQueen,
            request.HasCubs,request.AdicionalText,1);

            await _inspectionRepository.Add(inspection);
            await _unitOfWork.Save(cancellationToken);
            await _dispatcher.Dispatch(inspection, cancellationToken);
            return Outcomes.Success();
        }
    }
}