using System;
using System.Threading.Tasks;
using Ether.Outcomes;

namespace Hapibee.Backend.Application.Domain
{
    public interface IApiaryRepository
    {
        Task<IOutcome> Delete(Apiary apiary);

        Task<IOutcome<Apiary>> Find(string apiaryCode);

        Task<IOutcome> Add(Apiary apiary);
    }
}