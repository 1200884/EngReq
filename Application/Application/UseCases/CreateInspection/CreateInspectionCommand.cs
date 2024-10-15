using System.Collections.Generic;
using Ether.Outcomes;
using MediatR;

namespace Hapibee.Backend.Application.Application.UseCases.CreateInspection
{
    public sealed class CreateInspectionCommand : IRequest<IOutcome>
    {
        public CreateInspectionCommand( string inspectionCode, string beekeeperCode,string hiveCode,bool polen,bool honey,bool queen, bool  cubs, string description ,uint numberOfHandles
            )
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
        public CreateInspectionCommand( string inspectionCode, string beekeeperCode,string hiveCode,bool polen,bool honey,bool queen, bool  cubs ,uint numberOfHandles
            )
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
        public string BeekeeperCode { get; }
        public string HiveCode { get; }
        public bool HasPolen{ get; }
        public bool Hashoney{ get; }
        public bool HasQueen{ get; }
        public bool HasCubs{ get; }
        public string AdicionalText { get; }

    }
}