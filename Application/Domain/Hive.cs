using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    public sealed class Hive : Entity
    {
        private Hive()
        {
        }

        public Hive(string hiveCode, uint numberOfHandles)
        {
            HiveCode = hiveCode;
            NumberOfHandles = numberOfHandles;
            NumberOfQueenBees = 1;
        }

        public string HiveCode { get; }
        public uint NumberOfHandles { get; }
        public uint NumberOfQueenBees { get; }

        public Apiary Apiary { get; }
    }
}