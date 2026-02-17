using MediatR;

namespace Inventory.Application.Features.MeasurementUnits.Commands.CreateMeasurementUnit;

public record CreateMeasurementUnitCommand(string Name, string Abbreviation) : IRequest;