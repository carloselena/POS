using MediatR;
using System.Text.Json.Serialization;

namespace POS.Core.Application.Features.MeassurementUnits.Commands.UpdateMeasurementUnit
{
    public record UpdateMeasurementUnitCommand(
        [property: JsonIgnore] int Id,
        string Name,
        string Abbreviation
    ) : IRequest;
}
