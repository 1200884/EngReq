using System.Collections.Generic;
using MediatR;

namespace Hapibee.Backend.Application.Application.UseCases.GetAllBeekeeperHives
{
    public sealed class GetAllBeekeeperHivesQuery : IRequest<IReadOnlyList<BeekeeperHiveDto>>
    {
        public GetAllBeekeeperHivesQuery(string beekeeperCode)
        {
            BeekeeperCode = beekeeperCode;
        }

        public string BeekeeperCode { get; }
    }
}