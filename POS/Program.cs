using FluentValidation;
using FluentValidation.AspNetCore;
using POS.Core.Application;
using POS.Core.Application.Features.MeassurementUnits.Commands.CreateMeassurementUnit;
using POS.Infrastructure.Persistence;
using POS.Middleware;
using POS.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);

builder.Services.AddApiVersioningExtension();
builder.Services.AddHealthChecks();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateMeasurementUnitCommandValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandlerMiddleware();

app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
