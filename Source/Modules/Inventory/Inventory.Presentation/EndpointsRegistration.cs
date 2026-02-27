using Inventory.Presentation.Endpoints.MeasurementUnits;
using Microsoft.AspNetCore.Routing;
namespace Inventory.Presentation;

public static class EndpointsRegistration
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        #region MeasurementUnits
        app
            .MapCreateMeasurementUnitEndpoint()
            .MapGetMeasurementUnitsEndpoint()
            .MapGetMeasurementUnitByIdEndpoint();
        #endregion
        
        return app;
    }
}