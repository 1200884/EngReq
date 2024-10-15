using System.Threading.Tasks;
using Ether.Outcomes;

namespace Hapibee.Backend.Domain.Flights
{
    public interface IAircraftGateway
    {
        Task<IOutcome<Aircraft>> Find(string internalCode);
    }
}