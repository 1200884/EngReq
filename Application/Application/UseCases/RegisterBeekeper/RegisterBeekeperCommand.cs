using System.Collections.Generic;
using Ether.Outcomes;
using MediatR;

namespace Hapibee.Backend.Application.Application.UseCases.CreateApiary
{
    public sealed class CreateBeekeeperCommand : IRequest<IOutcome>
    {
        public CreateBeekeeperCommand(string name, string email, string password, string beekeeperCode)
        {
            Name = name;
            BeekeeperCode = beekeeperCode;
            Email = email;
            Password = password;
        }

        public string Name { get; }
        public string BeekeeperCode { get; }
        public string Email { get; }
        public string Password { get; }

        
    }
}