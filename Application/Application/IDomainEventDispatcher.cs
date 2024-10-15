using System.Threading;
using System.Threading.Tasks;
using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Application
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(Aggregate aggregate, CancellationToken cancellationToken);
    }
}