using Inventory.Application.Features.MeasurementUnits.Queries;
using Inventory.Application.Features.MeasurementUnits.Queries.GetAllMeasurementUnits;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Inventory.Presentation.Endpoints.MeasurementUnits;

public static class GetMeasurementUnitsEndpoint
{
    public static void MapGetMeasurementUnitsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/measurement-units", async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllMeasurementUnitsQuery());
            return Results.Ok(result);
        })
        .WithName("GetMeasurementUnits")
        .WithTags("MeasurementUnits")
        .Produces<List<MeasurementUnitDto>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}