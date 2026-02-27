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
        app.MapGet("/measurement-units", async (GetAllMeasurementUnitsQuery query, ISender sender) =>
        {
            var result = await sender.Send(query);
            return Results.Ok(result);
        });
    }
}