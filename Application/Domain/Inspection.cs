using Hapibee.Backend.Application.Domain.SeedWork;

namespace Hapibee.Backend.Application.Domain
{
    public sealed class Inspection : Entity
    {
        private Inspection()
        {
        }

        public Inspection(string inspectionCode, string beekeeperCode,string hiveCode,bool polen,bool honey,bool queen, bool  cubs, string description ,uint numberOfHandles)
        {
            InspectionCode=inspectionCode;
            BeekeeperCode = beekeeperCode;
            HiveCode = hiveCode;
            HasPolen=polen;
            HasHoney=honey;
            HasQueen=queen;
            HasCubs=cubs;
            AdicionalText=description;
            CreationDate = DateTime.Now;
            NumberOfHandles = numberOfHandles;
           
        }
        public Inspection( string inspectionCode,string beekeeperCode,string hiveCode,bool polen,bool honey,bool queen, bool  cubs ,uint numberOfHandles)
        {
            InspectionCode=inspectionCode;
            BeekeeperCode = beekeeperCode;
            HiveCode = hiveCode;
            HasPolen=polen;
            HasHoney=honey;
            HasQueen=queen;
            HasCubs=cubs;
            AdicionalText=null;
            CreationDate = DateTime.Now;
            NumberOfHandles = numberOfHandles;
           
        }

        public string InspectionCode { get; }
        public string HiveCode { get; }
        public bool HasPolen{ get; }
        public bool Hashoney{ get; }
        public bool HasQueen{ get; }
        public bool HasCubs{ get; }
        public string AdicionalText { get; }

        public uint NumberOfHandles { get; }
       

        public Apiary Apiary { get; }

    }
}