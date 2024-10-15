using System.Threading.Tasks;
using Ether.Outcomes;

namespace Hapibee.Backend.Domain.Flights
{
    public interface IAirportGateway
    {
        Task<IOutcome<Airport>> Find(string code);
    }
}