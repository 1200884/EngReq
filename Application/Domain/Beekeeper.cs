using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    public sealed class Beekeper : Entity
    {
        private Beekeper()
        {
        }

        public Beekeper(string name,string email, string password,string beekeeperCode)
        {
            BeekeeperCode = beekeeperCode;
            Name= name;
            Email=email;
            Password= password; 
        }

        public string BeekeeperCode { get; }
        public string Name { get; }
        public string Password { get; }
        public string Email { get; }

    }
}