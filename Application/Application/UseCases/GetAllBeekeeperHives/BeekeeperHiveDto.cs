namespace Hapibee.Backend.Application.Application.UseCases.GetAllBeekeeperHives
{
    public class BeekeeperHiveDto
    {
        public string BeekeeperCode { get; set; }
        public string HiveCode { get; set; }
        public string ApiaryCode { get; set; }
        public uint NumberOfHandles { get; set; }
        public uint NumberOfQueenBees { get; set; }
        public string State { get; set; }
    }
}