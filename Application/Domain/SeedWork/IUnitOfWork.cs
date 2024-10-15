using System.Threading;
using System.Threading.Tasks;

namespace Hapibee.Backend.Application.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken = default);
    }
}