using System;
using System.Threading.Tasks;
using Ether.Outcomes;

namespace Hapibee.Backend.Application.Domain
{
    public interface IInspectionRepository
    {
        Task<IOutcome> Delete(Inspection inspection);

        Task<IOutcome<Inspection>> Find(string inspectionCode);

        Task<IOutcome> Add(Inspection inspection);
    }
}