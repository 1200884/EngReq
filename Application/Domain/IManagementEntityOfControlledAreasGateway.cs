using System.Threading.Tasks;
using Ether.Outcomes;

namespace Hapibee.Backend.Application.Domain
{
    internal interface IManagementEntityOfControlledAreasGateway
    {
        Task<IOutcome<bool>> IsControlledArea(CoordinatePoints locationValue);
    }
}