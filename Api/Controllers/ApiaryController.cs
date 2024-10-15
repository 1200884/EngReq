using System.Threading.Tasks;
using Hapibee.Backend.Api.SeedWork;
using Hapibee.Backend.Application.Application.UseCases.CreateApiary;
using Hapibee.Backend.Application.Application.UseCases.GetAllBeekeeperHives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hapibee.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ApiaryController : BaseController
    {
        private readonly IMediator _mediator;

        public ApiaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApiary([FromBody] CreateApiaryCommand command)
        {
            return FromOutcome(await _mediator.Send(command));
        }

        [HttpGet("[action]/{beekeeperCode}")]
        public async Task<IActionResult> GetAllBeekeeperHives([FromRoute] string beekeeperCode)
        {
            return Ok(await _mediator.Send(new GetAllBeekeeperHivesQuery(beekeeperCode)));
        }
    }
}