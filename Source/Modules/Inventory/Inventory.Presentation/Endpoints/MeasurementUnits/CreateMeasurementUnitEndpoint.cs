using Inventory.Application.Features.MeasurementUnits.Commands.CreateMeasurementUnit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Inventory.Presentation.Endpoints.MeasurementUnits;

public static class CreateMeasurementUnitEndpoint
{
    public static void MapCreateMeasurementUnitEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/measurement-units", async (CreateMeasurementUnitCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.StatusCode(StatusCodes.Status201Created);
        })
        .WithName("CreateMeasurementUnit")
        .WithTags("MeasurementUnits")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status409Conflict)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}