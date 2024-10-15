using System.Threading;
using System.Threading.Tasks;
using Hapibee.Backend.Application.Domain.SeedWork;
using MediatR;

namespace Hapibee.Backend.Application.Application
{
    internal sealed class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(Aggregate aggregate, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in aggregate.GetDomainEvents())
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
        }
    }
}