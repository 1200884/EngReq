using System.Threading;
using System.Threading.Tasks;

namespace Hapibee.Backend.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken = default);
    }
}