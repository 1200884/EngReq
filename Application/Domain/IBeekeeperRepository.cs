using System;
using System.Threading.Tasks;
using Ether.Outcomes;

namespace Hapibee.Backend.Application.Domain
{
    public interface IBeekeeperRepository
    {
        Task<IOutcome> Delete(Beekeper beekeper);

        Task<IOutcome<Beekeper>> Find(string beekeperCode);

        Task<IOutcome> Add(Beekeper beekeper);
    }
}