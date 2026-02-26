using System.Reflection;
using Blocks.Application.Behaviors;
using FluentValidation;
using Inventory.Application.Features.MeasurementUnits.Commands.CreateMeasurementUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateMeasurementUnitCommandValidator>()
            .AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
    }
}