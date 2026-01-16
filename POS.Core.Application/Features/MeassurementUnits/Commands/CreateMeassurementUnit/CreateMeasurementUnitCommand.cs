using MediatR;

namespace POS.Core.Application.Features.MeassurementUnits.Commands.CreateMeassurementUnit
{
    public class CreateMeasurementUnitCommand : IRequest<int>
    {
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
    }
}
