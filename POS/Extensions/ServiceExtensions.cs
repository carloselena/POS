using Asp.Versioning;

namespace POS.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(configuration =>
            {
                configuration.DefaultApiVersion = new ApiVersion(1, 0);
                configuration.AssumeDefaultVersionWhenUnspecified = true;
                configuration.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
