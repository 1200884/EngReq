using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ether.Outcomes;
using Hapibee.Backend.Application.Domain;
using Hapibee.Backend.Application.Domain.SeedWork;
using MediatR;

namespace Hapibee.Backend.Application.Application.UseCases.CreateApiary
{
    internal sealed class CreateApiaryCommandHandler : IRequestHandler<CreateApiaryCommand, IOutcome>
    {
        private readonly IApiaryRepository _apiaryRepository;
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly IManagementEntityOfControlledAreasGateway _managementEntityOfControlledAreasGateway;
        private readonly IUnitOfWork _unitOfWork;

        public CreateApiaryCommandHandler(
            IManagementEntityOfControlledAreasGateway managementEntityOfControlledAreasGateway,
            IDomainEventDispatcher dispatcher, IApiaryRepository apiaryRepository, IUnitOfWork unitOfWork)
        {
            _managementEntityOfControlledAreasGateway = managementEntityOfControlledAreasGateway;
            _dispatcher = dispatcher;
            _apiaryRepository = apiaryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IOutcome> Handle(CreateApiaryCommand request, CancellationToken cancellationToken)
        {
            var location = CoordinatePoints.Create(request.LocationLatitude, request.LocationLongitude);
            if (location.Failure)
            {
                return location;
            }

            var apiaryLookup = await _apiaryRepository.Find(request.ApiaryCode);
            if (apiaryLookup.Success)
            {
                return Outcomes.Failure().WithMessage($"Apiary with ApiaryCode: {request.ApiaryCode} already exists");
            }

            var isControlledArea = await _managementEntityOfControlledAreasGateway.IsControlledArea(location.Value);
            
            var apiary = new Apiary(request.BeekeeperCode,
                request.ApiaryCode,
                isControlledArea.Value, 
                location.Value,
                request.Hives
                    .Select(createHive => (createHive.HiveCode, createHive.NumberOfHandles))
                    .ToArray());

            await _apiaryRepository.Add(apiary);
            await _unitOfWork.Save(cancellationToken);
            await _dispatcher.Dispatch(apiary, cancellationToken);
            return Outcomes.Success();
        }
    }
}